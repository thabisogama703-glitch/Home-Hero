using HomeHero_2;

namespace Home_Hero
{
    /// <summary>The kinds of account an e-mail address can belong to.</summary>
    [Flags]
    public enum AccountKinds
    {
        None = 0,
        Customer = 1,
        Provider = 2,
        Administrator = 4
    }

    /// <summary>
    /// One place that knows every account in the app (customers, service providers, administrators).
    /// The login screen uses it to work out WHO is signing in, so nobody has to say "log in as ..."
    /// and the sign-up screens use it to keep one e-mail address = one identity.
    /// </summary>
    public static class AccountDirectory
    {
        private static readonly object registrationLock = new object();

        // Administrator accounts are hard-coded (see README "Known limitations").
        private static readonly (string Name, string Email, string Password)[] Admins =
        {
            ("Thabiso",  "thabisogama703@gmail.com", "@Thandolwami07"),
            ("Sibusiso", "shadowsilver308@gmail.com", "@Thandolwami07"),
        };

        private static string Clean(string? email)
        {
            return (email ?? "").Trim().ToLowerInvariant();
        }

        // ------------------------------------------------------------------
        //  Which kinds of account use this e-mail address? (password not needed)
        // ------------------------------------------------------------------
        public static AccountKinds Detect(string? email)
        {
            string e = Clean(email);
            AccountKinds kinds = AccountKinds.None;
            if (e.Length == 0) return kinds;

            if (Admins.Any(a => a.Email == e)) kinds |= AccountKinds.Administrator;
            if (CustomerExists(e)) kinds |= AccountKinds.Customer;
            if (ProviderExists(e)) kinds |= AccountKinds.Provider;
            return kinds;
        }

        public static bool TryRegisterCustomer(Customer customer, out AccountKinds existingKinds, out string error)
        {
            lock (registrationLock)
            {
                existingKinds = Detect(customer.Email);
                error = "";
                if (existingKinds != AccountKinds.None) return false;

                try
                {
                    string email = Clean(customer.Email);
                    customer.WriteToFile(
                        (customer.FirstName + " " + customer.LastName).Trim(),
                        email,
                        customer.PhoneNumber,
                        customer.Password);
                    CustomerRepository.Customers.Add(customer);
                    return true;
                }
                catch (IOException ex)
                {
                    error = "The customer account could not be saved. " + ex.Message;
                    return false;
                }
                catch (UnauthorizedAccessException ex)
                {
                    error = "HomeHero does not have permission to save the customer account. " + ex.Message;
                    return false;
                }
            }
        }

        public static bool TryRegisterProvider(ServiceProvider provider, out AccountKinds existingKinds, out string error)
        {
            lock (registrationLock)
            {
                existingKinds = Detect(provider.Email);
                error = "";
                if (existingKinds != AccountKinds.None) return false;

                try
                {
                    if (DataManager.AddServiceProvider(provider)) return true;
                    error = "The service provider account could not be saved.";
                    return false;
                }
                catch (IOException ex)
                {
                    error = "The service provider account could not be saved. " + ex.Message;
                    return false;
                }
                catch (UnauthorizedAccessException ex)
                {
                    error = "HomeHero does not have permission to save the service provider account. " + ex.Message;
                    return false;
                }
            }
        }

        public static bool TryRemoveCustomer(Customer customer, out string error)
        {
            lock (registrationLock)
            {
                error = "";
                string file = AppPaths.DataFile("customers.txt");
                if (!File.Exists(file))
                {
                    error = "The customer account file could not be found.";
                    return false;
                }

                try
                {
                    string[] lines = File.ReadAllLines(file);
                    int match = Array.FindLastIndex(lines, line =>
                    {
                        string[] parts = line.Split('|');
                        return parts.Length >= 4
                            && Clean(parts[1]) == Clean(customer.Email)
                            && parts[3].Trim() == customer.Password;
                    });
                    if (match < 0)
                    {
                        error = "The new customer account could not be found for rollback.";
                        return false;
                    }

                    File.WriteAllLines(file, lines.Where((line, index) => index != match));
                    CustomerRepository.Customers.Remove(customer);
                    return true;
                }
                catch (IOException ex)
                {
                    error = "The customer account could not be rolled back. " + ex.Message;
                    return false;
                }
                catch (UnauthorizedAccessException ex)
                {
                    error = "HomeHero does not have permission to roll back the customer account. " + ex.Message;
                    return false;
                }
            }
        }

        // ------------------------------------------------------------------
        //  Credential checks
        // ------------------------------------------------------------------
        /// <summary>Returns the administrator's first name when the credentials are right, otherwise null.</summary>
        public static string? CheckAdministrator(string? email, string? password)
        {
            string e = Clean(email);
            foreach (var a in Admins)
            {
                if (a.Email == e && (password ?? "").Trim() == a.Password) return a.Name;
            }
            return null;
        }

        public static bool CheckCustomer(string? email, string? password)
        {
            string e = Clean(email);
            string p = (password ?? "").Trim();
            foreach (string[] parts in ReadCustomerLines())
            {
                if (parts[1].Trim().ToLowerInvariant() == e && parts[3].Trim() == p) return true;
            }
            return false;
        }

        public static ServiceProvider? CheckProvider(string? email, string? password)
        {
            string e = Clean(email);
            string p = password ?? "";

            ServiceProvider? match = DataManager.LoadServiceProviders().FirstOrDefault(sp =>
                Clean(sp.Email) == e && sp.VerifyPassword(p));

            return match ?? FindLegacyProvider(e, p);
        }

        // ------------------------------------------------------------------
        //  Existence checks
        // ------------------------------------------------------------------
        private static bool CustomerExists(string cleanEmail)
        {
            return ReadCustomerLines().Any(parts => parts[1].Trim().ToLowerInvariant() == cleanEmail);
        }

        private static bool ProviderExists(string cleanEmail)
        {
            if (DataManager.LoadServiceProviders().Any(sp => Clean(sp.Email) == cleanEmail)) return true;
            return ReadLegacyProviderLines().Any(parts => Clean(parts[1]) == cleanEmail);
        }

        // ------------------------------------------------------------------
        //  Storage helpers
        // ------------------------------------------------------------------
        // customers.txt line format:  Name | email | phone | password
        private static IEnumerable<string[]> ReadCustomerLines()
        {
            string file = AppPaths.DataFile("customers.txt");
            if (!File.Exists(file)) yield break;

            string[] lines;
            lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 4) yield return parts;
            }
        }

        // Providers who registered before accounts moved to providers.json (Service.txt).
        private static IEnumerable<string[]> ReadLegacyProviderLines()
        {
            string file = AppPaths.DataFile("Service.txt");
            if (!File.Exists(file)) yield break;

            string[] lines;
            lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 6) yield return parts;
            }
        }

        private static ServiceProvider? FindLegacyProvider(string cleanEmail, string password)
        {
            foreach (string[] data in ReadLegacyProviderLines())
            {
                if (Clean(data[1]) == cleanEmail && data[2] == password)
                {
                    List<string> specialisation = new List<string>();
                    if (!data[5].StartsWith("System.", StringComparison.Ordinal) && data[5].Trim().Length > 0)
                        specialisation.Add(data[5]);

                    return new ServiceProvider(data[0], "", data[1], data[2], data[3], data[4], specialisation);
                }
            }
            return null;
        }
    }
}
