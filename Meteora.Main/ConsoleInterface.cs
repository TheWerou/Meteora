namespace Meteora.Main
{
    public class ConsoleInterface
    {
        public void CleareScreen()
        {
            Console.Clear();
        }

        public void GenerateWelcomeScreen()
        {
            Console.WriteLine("---- Welcome ----");
            Console.Write(" 1. Start new game.");
            Console.Write(" 2. Exit");
            Console.WriteLine($"");
        }

        public void GenerateUserPanel(int hp, int points)
        {
            Console.WriteLine("");
            Console.WriteLine("---- User ----");
            Console.WriteLine($"HP: {hp}");
            Console.WriteLine($"Points: {points}");
            Console.WriteLine($"---- ---- ----");
        }

        public void GenerateShop()
        {
            Console.WriteLine("---- Welcome to shop ----");
            int counter = 2;
            Console.Write($" 1. Exit");
            foreach (var item in Data.Vowels)
            {
                Console.Write($" {counter}. {item}.");
                counter++;
            }
            Console.WriteLine($"");
        }

        public void GeneratePasswordPanel(string password)
        {
            Console.WriteLine("");
            Console.WriteLine("---- Fortune weel ----");
            Console.Write("--->   ");
            foreach (var letter in password)
            {
                Console.Write(letter);
            }
            Console.WriteLine("");
            Console.WriteLine("---- ------- ---- ----");
        }
        public void GenerateUserInstructions()
        {
            Console.WriteLine("");
            Console.Write("---- Options:");
            Console.Write(" 1. Provide letter.");
            Console.Write(" 2. Shop.");
            Console.Write(" 3. Exit");
            Console.Write(" ----");
            Console.WriteLine("");
        }

        public void GenerateChoseDifficulty()
        {
            Console.WriteLine("");
            Console.WriteLine("---- Chose your Difficulty ----");
            Console.Write("---- Options:");
            Console.Write(" 1. Easy(500).");
            Console.Write(" 2. Medium(300).");
            Console.Write(" 3. Hard(200).");
            Console.Write(" 4. God(100)");
            Console.Write(" 5. Exit");
            Console.Write(" ----");
            Console.WriteLine("");
        }

        public void GenerateChoseCategory()
        {
            Console.WriteLine("");
            Console.WriteLine("---- Chose your Category ----");
            Console.Write("---- Options:");
            Console.Write(" 1. Capital Cities.");
            Console.Write(" 2. Countries.");
            Console.Write(" 3. Car Brand.");
            Console.Write(" 4. Sport Disciplne");
            Console.Write(" 5. Exit");
            Console.Write(" ----");
            Console.WriteLine("");
        }

        public void GenerateWin()
        {
            Console.WriteLine("");
            Console.WriteLine("---- Congratulation ----");
            Console.WriteLine("---- You have won ----");
            Console.WriteLine("---- Congratulation ----");
        }

        public void GenerateLose()
        {
            Console.WriteLine("");
            Console.WriteLine("---- We are so sorry ----");
            Console.WriteLine("---- You have lose ----");
            Console.WriteLine("---- We are so sorry ----");
        }

        public void GenerateNewGame()
        {
            Console.WriteLine("");
            Console.Write("---- Options:");
            Console.Write(" 1. New game.");
            Console.Write(" 2. Exit");
            Console.Write(" ----");
            Console.WriteLine("");
        }

        public void GenerateError()
        {
            Console.Write("[Wrong option]");
        }

        public void GenerateGoodBye()
        {
            Console.WriteLine("Goodbye");
        }

        public void GetUserResponse(out string userResponse, string? text = null)
        {
            if (text != null)
            {
                Console.Write($"{text} ");
            }

            Console.Write("> ");
            userResponse = Console.ReadLine() ?? "";
        }
    }
}
