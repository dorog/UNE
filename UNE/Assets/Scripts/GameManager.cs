using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStarter gameStarter;
    public GameEnder gameEnder;

    public RoundManager roundManager;

    public void StartGame()
    {
        gameStarter.StartGame();
    }

    public void EndGame()
    {
        roundManager.GameOver();

        gameEnder.EndGame();
    }

    public void Quit()
    {
        Application.Quit();   
    }
}
