using System;
using System.Globalization;
using System.IO;

namespace Home_Hero
{
    /// <summary>
    /// Remembers who is logged in as a customer so every customer screen
    /// (dashboard welcome, active requests, service history, new requests,
    /// request tracking) works with that person's own data.
    /// </summary>
    public static class CustomerSession
    {
        // Used only if a customer screen is opened without logging in (e.g. while testing).
        private const string GuestId = "11";

        public static string Name { get; private set; } = "";
        public static string Email { get; private set; } = "";

        public static bool IsSignedIn
        {
            get { return !string.IsNullOrWhiteSpace(Email); }
        }

        /// <summary>The id stored on each request (the customer's e-mail address).</summary>
        public static string CustomerId
        {
            get { return IsSignedIn ? Email : GuestId; }
        }

        /// <summary>Call straight after a successful customer login.</summary>
        public static void SignIn(string email)
        {
            Email = (email ?? "").Trim().ToLower();
            Name = LookUpName(Email);
        }

        public static void SignOut()
        {
            Email = "";
            Name = "";
        }

        // customers.txt line format:  Name | email | phone | password
        private static string LookUpName(string email)
        {
            try
            {
                string customersFile = AppPaths.DataFile("customers.txt");
                if (!File.Exists(customersFile)) return "";

                foreach (string line in File.ReadAllLines(customersFile))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length < 2) continue;

                    if (parts[1].Trim().ToLower() == email)
                    {
                        string name = parts[0].Trim();
                        if (name.Length == 0) return "";
                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                    }
                }
            }
            catch (Exception)
            {
                // A name that cannot be read just means a plain "Welcome back!".
            }
            return "";
        }
    }
}
