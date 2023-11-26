namespace Meteora.Main.Model
{
    public interface IUser
    {
        int Lives { get; }
        int Points { get; set; }

        void HitUser(int points);
        bool IsUserAlive();
        void ResetUser();
        bool TryBuy();
    }
}