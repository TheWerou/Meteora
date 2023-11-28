namespace Meteora.Main
{
    public class Data
    {
        public static IEnumerable<int> AmountsOptions = new List<int>()
        {
            100, 200, 300, 500
        };

        public static IEnumerable<string> Vowels = new[] { "a", "e", "i", "o", "u", "y" };

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

        public static IEnumerable<int> WelcomeScreenOptions = new[] { 1, 2 };
        public static IEnumerable<int> StartGameScreenOptions = new[] { 1, 2, 3, 4, 5 };
        public static IEnumerable<int> GameScreenOptions = new[] { 1, 2, 3 };
        public static IEnumerable<int> EndGameScreenOptions = new[] { 1, 2 };
    }
}
