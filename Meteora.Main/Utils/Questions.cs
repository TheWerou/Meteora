namespace Meteora.Main.Utils
{
    public static class Questions
    {
        public static IEnumerable<string> CapitalCities
        {
            get
            {
                return new[]
                {
                     "Warsow",
                     "Gdansk",
                     "NewYork",
                     "Koszalin",
                     "Torun"
                };
            }
        }

        public static IEnumerable<string> Countries
        {
            get
            {
                return new[]
                {
                     "Poland",
                     "France",
                     "England",
                     "Spain",
                     "USA"
                };
            }
        }

        public static IEnumerable<string> CarBrand
        {
            get
            {
                return new[]
                {
                     "Tesla",
                     "Ford",
                     "Skoda",
                     "BMW",
                     "Citroen"
                };
            }
        }

        public static IEnumerable<string> SportDisciplne
        {
            get
            {
                return new[]
                {
                     "Running",
                     "Swimming",
                     "Gym",
                     "Dancing",
                     "Javelin"
                };
            }
        }
    }
}
