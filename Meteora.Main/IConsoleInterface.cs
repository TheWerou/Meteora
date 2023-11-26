namespace Meteora.Main
{
    public interface IConsoleInterface
    {
        ConsoleInterface CleareScreen();
        ConsoleInterface GenerateChoseCategory();
        ConsoleInterface GenerateChoseDifficulty();
        ConsoleInterface GenerateError();
        ConsoleInterface GenerateGoodBye();
        ConsoleInterface GenerateLose();
        ConsoleInterface GenerateNewGame();
        ConsoleInterface GeneratePasswordPanel(string password);
        ConsoleInterface GenerateShop();
        ConsoleInterface GenerateUserInstructions();
        ConsoleInterface GenerateUserPanel(int hp, int points);
        ConsoleInterface GenerateWelcomeScreen();
        ConsoleInterface GenerateWin();
        ConsoleInterface GetUserResponse(out string userResponse, string? text = null);
    }
}