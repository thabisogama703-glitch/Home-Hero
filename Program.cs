namespace ServiceProviderDashboard
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            ServiceProvider provider = new ServiceProvider("John",
                "Smith",
                "john@email.com",
                "12345",
                "0712345678");
            Customer customer = new Customer("Sarah", "Mokoena", "sarah@email.com", "0723456789", "12345");
            Service service = new Service(Guid.NewGuid(), "Plumbing", "Fix leaking pipes", 850.00m, "Home Maintenance");
            MaintenanceRequest request = customer.SubmitRequest(service, "Kitchen sink is leaking");
            request.AssignProvider(provider);
            Appointment appointment = new Appointment(request, provider, DateTime.Now.AddDays(1));
            Job job = new Job(appointment);
            provider.JobAccepted(job);
            Application.Run(new frmServiceProviderDashboard(provider));
            
        }
    }
}