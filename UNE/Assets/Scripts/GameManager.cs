using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStarter gameStarter;
    public GameEnder gameEnder;

    public void StartGame()
    {
        gameStarter.StartGame();
    }

    public void EndGame()
    {
        gameEnder.EndGame();
    }

    public void Quit()
    {
        Application.Quit();   
    }
}
