namespace Meteora.Main
{
    public interface IPasswordHandler
    {
        string CurrentHiddenPassword { get; }
        string CurrentPassword { get; }

        bool IsPasswordGuessed();
        bool TryShowLetter(char letter, out int foundLetters);
    }
}