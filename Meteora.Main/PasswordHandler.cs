using Meteora.Main.Extentions;

namespace Meteora.Main
{
    public class PasswordHandler : IPasswordHandler
    {
        public PasswordHandler(string password)
        {
            password = password.ToLower();
            _currentHiddenPassword = password.Select(x => '#').ToList();
            _currentPassword = password.ToList();
        }

        private List<char> _currentPassword;
        public string CurrentPassword
        {
            get { return new string(_currentPassword.ToArray()); }
        }

        private List<char> _currentHiddenPassword;
        public string CurrentHiddenPassword
        {
            get { return new string(_currentHiddenPassword.ToArray()); }
        }

        public bool TryShowLetter(char letter, out int foundLetters)
        {
            foundLetters = 0;
            var indexes = _currentPassword.AllIndexesOf(letter);
            if (!indexes.Any())
                return false;

            foundLetters = indexes.Count();

            foreach (var index in indexes)
            {
                var foundLetter = _currentPassword[index];
                _currentHiddenPassword[index] = foundLetter;
            }

            return true;
        }

        public bool IsPasswordGuessed()
        {
            return _currentHiddenPassword.SequenceEqual(_currentPassword);
        }
    }
}
