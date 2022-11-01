namespace BubblesShoot.View.Interfaces
{
    public interface IPauseStateControl 
    {
        void PauseGame();
        void ContinueGame();
        void QuitGame(bool restart);
    }

    public interface IQuitControl
    {
        void QuitGame(bool restart);
    }

    public interface IRaycastControl
    {
        void BlockRaycast();
        void ContinueRaycast();
    }
}
