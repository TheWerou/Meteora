namespace Meteora.Main.Model
{
    public class User
    {
        public int Points { get; set; }

        private int _lives = 3;
        public int Lives 
        { 
            get 
            {
                return _lives;
            } 
        }

        public bool IsUserAlive() 
        {
            return _lives > 0;
        }

        public void HitUser(int points) 
        {
            _lives -= points;
        }

        public void ResetUser() 
        {
            Points = 0;
            _lives = 3;
        }

        public bool TryBuy()
        {
            if (Points < 100) 
                return false;
            
            Points -= 100;
            return true;
        }
    }
}
