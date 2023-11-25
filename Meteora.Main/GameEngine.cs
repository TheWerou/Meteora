using Meteora.Main.Extentions;
using Meteora.Main.Model;
using Meteora.Main.Utils;

namespace Meteora.Main
{
    public class GameEngine
    {
        public GameEngine()
        {
            _user = new User();
            _interface = new ConsoleInterface();
            _vowels = Letters.Vowels.ToList();
        }

        private User _user;
        private PasswordHandler _passwordHandler;
        private ConsoleInterface _interface;
        private List<string> _vowels;
        private string _userResponse;

        private IEnumerable<int> _welcomeScreenOptions = new[] { 1, 2 }; 
        private IEnumerable<int> _startGameScreenOptions = new[] { 1, 2, 3, 4, 5 }; 
        private IEnumerable<int> _gameScreenOptions = new[] { 1, 2, 3 }; 
        private IEnumerable<int> _endGameScreenOptions = new[] { 1, 2 }; 

        public void Run() 
        {
            var selectedOption = WelcomeScreen();
            if (selectedOption == 2) 
            {
                Exit();
                return;
            }
                
            StartGame();
        }

        public void Exit() 
        {
            _interface
                .CleareScreen()
                .GenerateGoodBye();
        }

        public void StartGame() 
        {   
            var selectedOption = StartGameScreenDificulty();
            if (selectedOption == 5)
            {
                Exit();
                return;
            }

            SetDifficulty(selectedOption);

            selectedOption = StartGameScreen();
            if (selectedOption == 5)
            {
                Exit();
                return;
            }
                
            GetNewPassword(selectedOption);

            while (true)
            {
                while(true) 
                {
                    selectedOption = GameScreen();
                    if (selectedOption == 3)
                        return;
                    else if (selectedOption == 2)
                    {
                        ShopScreen();
                    }
                    else if (selectedOption == 1)
                    {
                        GuessLetterScreen();
                        break;
                    }
                }

                if (_passwordHandler.IsPasswordGuessed()) 
                {
                    EndGame(true);
                    break;
                }
                    
                if (!_user.IsUserAlive()) 
                {
                    EndGame(false);
                    break;
                }
            }
        }

        private void ShopScreen() 
        {
            _interface.CleareScreen()
                .GenerateShop()
                .GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                var listOfLetters = _vowels.ToList();
                var isIndexCorrect = listOfLetters.Count > option || option < 0;

                if (!successfullyParsed)
                {
                    WrongShopScreen();
                    continue;
                }

                if (option == 1)
                    break;
                
                if (!isIndexCorrect)
                {
                    WrongShopScreen();
                    continue;
                }

                if (!_user.TryBuy())
                {
                    WrongShopScreen();
                    continue;
                }

                AddRemovePoints();
                _vowels.RemoveAt(option);
            }
        }

        private void WrongShopScreen() 
        {
            _interface.CleareScreen()
                .GenerateShop()
                .GenerateError()
                .GetUserResponse(out _userResponse);
        }

        private void EndGame(bool isGameWon) 
        {
            var selectedOption = WinScreen(isGameWon);
            if (selectedOption == 2)
                Exit();
            else if (selectedOption == 1)
                StartGame();
        }

        private void GuessLetterScreen() 
        {
            int option;

            _interface.GetUserResponse(out _userResponse, "Provide letter");
            var successfullyParsed = int.TryParse(_userResponse, out option);
            if (_userResponse == "" || successfullyParsed)
            {
                _interface.CleareScreen().GenerateError();
                Thread.Sleep(2000);
                return;
            }

            AddRemovePoints();
        }

        private void AddRemovePoints() 
        {
            int foundLetters = 0;
            var hasLaterChanged = _passwordHandler.TryShowLetter(_userResponse.ToLower()[0], out foundLetters);
            if (!hasLaterChanged)
                _user.HitUser(1);

            _user.Points += foundLetters * 50;
        }

        private void GetNewPassword(int option) 
        {
            switch (option)
            {
                case 1:
                    _passwordHandler = new PasswordHandler(Questions.CapitalCities.RandomElement());
                    break;
                case 2:
                    _passwordHandler = new PasswordHandler(Questions.Countries.RandomElement());
                    break;
                case 3:
                    _passwordHandler = new PasswordHandler(Questions.CarBrand.RandomElement());
                    break;
                case 4:
                    _passwordHandler = new PasswordHandler(Questions.SportDisciplne.RandomElement());
                    break;
                default:
                    break;
            }
        }

        private void SetDifficulty(int option)
        {
            switch (option)
            {
                case 1:
                    _user.Points = 500;
                    break;
                case 2:
                    _user.Points = 300;
                    break;
                case 3:
                    _user.Points = 200;
                    break;
                case 4:
                    _user.Points = 100;
                    break;
                default:
                    break;
            }
        }

        private int WelcomeScreen() 
        {
            _interface
                .GenerateWelcomeScreen()
                .GetUserResponse(out _userResponse);

            while (true) 
            { 
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !_welcomeScreenOptions.Contains(option))
                {
                    _interface
                        .CleareScreen()
                        .GenerateWelcomeScreen()
                        .GenerateError()
                        .GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }

        private int StartGameScreenDificulty()
        {
            _interface
                .CleareScreen()
                .GenerateChoseDifficulty()
                .GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !_startGameScreenOptions.Contains(option))
                {
                    _interface
                        .CleareScreen()
                        .GenerateChoseDifficulty()
                        .GenerateError()
                        .GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }

        private int StartGameScreen() 
        {
            _interface
                .CleareScreen()
                .GenerateChoseCategory()
                .GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !_startGameScreenOptions.Contains(option))
                {
                    _interface
                        .CleareScreen()
                        .GenerateChoseCategory()
                        .GenerateError()
                        .GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }

        private int GameScreen() 
        {
            _interface.CleareScreen()
                .GenerateUserPanel(_user.Lives, _user.Points)
                .GeneratePasswordPanel(_passwordHandler.CurrentHiddenPassword)
                .GenerateUserInstructions()
                .GetUserResponse(out _userResponse);

            while (true) 
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !_gameScreenOptions.Contains(option))
                {
                    _interface
                        .CleareScreen()
                        .GenerateUserPanel(_user.Lives, _user.Points)
                        .GeneratePasswordPanel(_passwordHandler.CurrentHiddenPassword)
                        .GenerateUserInstructions()
                        .GenerateError()
                        .GetUserResponse(out _userResponse);
                    continue;
                }
                return option;
            }
        }

        private int WinScreen(bool isWin) 
        {
            _interface.CleareScreen();

            if (isWin) 
            {
                _interface.GenerateWin();
            }
            else
            {
                _interface
                    .GenerateLose();
            }

            _interface
                .GenerateNewGame()
                .GetUserResponse(out _userResponse);

            int option;

            while (true) 
            {
                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !_endGameScreenOptions.Contains(option))
                {
                    _interface
                        .GenerateNewGame()
                        .GenerateError()
                        .GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }
    }
}
