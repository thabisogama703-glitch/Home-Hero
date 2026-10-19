namespace Home_Hero
{
    public sealed record HomeServiceOption(string Name, string Description, decimal StartingPrice);

    public static class HomeServiceCatalog
    {
        public static IReadOnlyList<HomeServiceOption> Services { get; } = new[]
        {
            new HomeServiceOption("Windows and Doors", "Repairs, fittings, locks, handles and basic maintenance.", 600m),
            new HomeServiceOption("Plumbing", "Small repairs, leaking taps, blocked drains and basic plumbing work.", 650m),
            new HomeServiceOption("Electrical", "Basic electrical repairs, installations and fault finding.", 750m),
            new HomeServiceOption("HVAC", "Air-conditioner servicing, repairs and basic HVAC maintenance.", 650m),
            new HomeServiceOption("Roofing", "Minor roof repairs, leaks and maintenance.", 400m),
            new HomeServiceOption("Landscaping", "Garden maintenance, trimming, cleanup and basic landscaping.", 500m),
            new HomeServiceOption("Painting", "Small-room painting and basic interior/exterior painting work.", 450m),
            new HomeServiceOption("Deep Cleaning", "Deep cleaning for homes, kitchens, bathrooms and other areas.", 450m),
            new HomeServiceOption("Appliance Repair", "Appliance diagnostics and small repairs.", 600m),
            new HomeServiceOption("General Maintenance", "Small household repairs and maintenance tasks.", 550m)
        };

        public static string NormalizeCategory(string? category)
        {
            string normalized = (category ?? string.Empty).Trim();
            foreach (string prefix in new[] { "🔧", "⚡", "🔌", "🎨", "🌿", "🏠" })
            {
                normalized = normalized.Replace(prefix, string.Empty, StringComparison.Ordinal).Trim();
            }

            if (string.Equals(normalized, "WindowsDoors", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(normalized, "Windows & Doors", StringComparison.OrdinalIgnoreCase))
            {
                return "Windows and Doors";
            }

            if (string.Equals(normalized, "DeepCleaning", StringComparison.OrdinalIgnoreCase))
            {
                return "Deep Cleaning";
            }

            return normalized;
        }

        public static decimal GetStartingPrice(string? category)
        {
            string normalized = NormalizeCategory(category);
            return Services.FirstOrDefault(service =>
                string.Equals(service.Name, normalized, StringComparison.OrdinalIgnoreCase))?.StartingPrice ?? 250m;
        }
    }
}
