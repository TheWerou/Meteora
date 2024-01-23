namespace Meteora.Main
{
    public class GameEngine
    {
        private User _user;
        private PasswordHandler _passwordHandler;
        private ConsoleInterface _interface;
        private List<string> _vowels;
        private string _userResponse;
        private int _gamePrice = 0;

        public GameEngine(User user, ConsoleInterface consoleInterface)
        {
            _user = user;
            _interface = consoleInterface;
            _vowels = Data.Vowels.ToList();
        }

        public void Run()
        {
            var selectedOption = WelcomeScreen();
            if (selectedOption != 2)
                StartGame();

            Exit();
        }

        public void Exit()
        {
            _interface.CleareScreen();
            _interface.GenerateGoodBye();
        }

        public void StartGame()
        {
            DrawPoints();

            var selectedOption = StartGameScreen();
            if (selectedOption == 5)
            {
                Exit();
                return;
            }

            GetNewPassword(selectedOption);

            MainGameLoop();
        }

        private void MainGameLoop()
        {
            while (true)
            {
                while (true)
                {
                    var selectedOption = GameScreen();
                    if (selectedOption == 4)
                        return;
                    else if (selectedOption == 1)
                    {
                        GuessLetterScreen();
                        break;
                    }
                    else if (selectedOption == 3)
                    {
                        ShopScreen();
                    }
                    else if (selectedOption == 2)
                    {
                        GuessPassword();
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
            _interface.CleareScreen();
            _interface.GenerateUserPanel(_user.Lives, _user.Points);
            _interface.GenerateShop();
            _interface.GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                var listOfLetters = _vowels.ToList();
                var index = option - 2;

                var isIndexCorrect = listOfLetters.Count > index || index < 0;

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

                _userResponse = listOfLetters[index];
                AddRemovePoints(false);
                _vowels.RemoveAt(index);
                break;
            }
        }

        private void WrongShopScreen()
        {
            _interface.CleareScreen();
            _interface.GenerateShop();
            _interface.GenerateError();
            _interface.GetUserResponse(out _userResponse);
        }

        private void EndGame(bool isGameWon)
        {
            var selectedOption = WinScreen(isGameWon);
            if (selectedOption == 2)
                Exit();
            else if (selectedOption == 1)
            {
                _user.ResetUser();
                StartGame();
            }
        }

        private void GuessLetterScreen()
        {
            int option;

            _interface.GetUserResponse(out _userResponse, "Provide letter");
            var successfullyParsed = int.TryParse(_userResponse, out option);
            if (_userResponse == "" || successfullyParsed)
            {
                _interface.CleareScreen();
                _interface.GenerateError();
                Thread.Sleep(2000);
                return;
            }

            AddRemovePoints(true);
        }

        private void GuessPassword()
        {
            int option;

            _interface.GetUserResponse(out _userResponse, "Provide password");
            var successfullyParsed = int.TryParse(_userResponse, out option);
            if (_userResponse == "" || successfullyParsed)
            {
                _interface.CleareScreen();
                _interface.GenerateError();
                Thread.Sleep(2000);
                return;
            }

            AddRemovePointsPasword();
        }

        private void AddRemovePoints(bool canAddPoints)
        {
            int foundLetters = 0;
            var hasLaterChanged = _passwordHandler.TryShowLetter(_userResponse.ToLower()[0], out foundLetters);
            if (!hasLaterChanged && canAddPoints)
                _user.HitUser(1);

            if (canAddPoints)
                _user.Points += foundLetters * _gamePrice;
        }

        private void AddRemovePointsPasword()
        {
            var hasLaterChanged = _passwordHandler.TryShowPassword(_userResponse.ToLower());
            if (!hasLaterChanged)
                _user.HitUser(1);
        }

        private void GetNewPassword(int option)
        {
            switch (option)
            {
                case 1:
                    _passwordHandler = new PasswordHandler(Data.CapitalCities.RandomElement());
                    break;
                case 2:
                    _passwordHandler = new PasswordHandler(Data.Countries.RandomElement());
                    break;
                case 3:
                    _passwordHandler = new PasswordHandler(Data.CarBrand.RandomElement());
                    break;
                case 4:
                    _passwordHandler = new PasswordHandler(Data.SportDisciplne.RandomElement());
                    break;
                default:
                    break;
            }
        }

        private void DrawPoints()
        {
            _gamePrice = Data.PossiblePoints.RandomElement();
        }

        private int WelcomeScreen()
        {
            _interface.GenerateWelcomeScreen();
            _interface.GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !Data.WelcomeScreenOptions.Contains(option))
                {
                    _interface.CleareScreen();
                    _interface.GenerateWelcomeScreen();
                    _interface.GenerateError();
                    _interface.GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }

        private int StartGameScreen()
        {
            _interface.CleareScreen();
            _interface.GenerateChoseCategory();
            _interface.GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !Data.StartGameScreenOptions.Contains(option))
                {
                    _interface.CleareScreen();
                    _interface.GenerateChoseCategory();
                    _interface.GenerateError();
                    _interface.GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }

        private int GameScreen()
        {
            _interface.CleareScreen();
            _interface.GenerateUserPanel(_user.Lives, _user.Points);
            _interface.GeneratePasswordPanel(_passwordHandler.CurrentHiddenPassword);
            _interface.GenerateUserInstructions();
            _interface.GetUserResponse(out _userResponse);

            while (true)
            {
                int option;

                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !Data.GameScreenOptions.Contains(option))
                {
                    _interface.CleareScreen();
                    _interface.GenerateUserPanel(_user.Lives, _user.Points);
                    _interface.GeneratePasswordPanel(_passwordHandler.CurrentHiddenPassword);
                    _interface.GenerateUserInstructions();
                    _interface.GenerateError();
                    _interface.GetUserResponse(out _userResponse);
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
                _interface.GenerateLose();
            }

            _interface.GenerateNewGame();
            _interface.GetUserResponse(out _userResponse);

            int option;

            while (true)
            {
                var successfullyParsed = int.TryParse(_userResponse, out option);
                if (!successfullyParsed && !Data.EndGameScreenOptions.Contains(option))
                {
                    _interface.GenerateNewGame();
                    _interface.GenerateError();
                    _interface.GetUserResponse(out _userResponse);
                    continue;
                }

                return option;
            }
        }
    }
}
