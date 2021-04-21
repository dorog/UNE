using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject root;

    public Image background;
    public Color winColor;
    public Color loseColor;

    public Text playerResult;

    public Table table;

    public void ShowUI(bool isPlayerWon)
    {
        background.color = isPlayerWon ? winColor : loseColor;
        playerResult.text = isPlayerWon ? "You win!" : "You lose!";

        root.SetActive(true);
    }

    public void PlayAgain()
    {
        table.StartGame();

        HideUI();
    }

    public void HideUI()
    {
        root.SetActive(false);
    }
}
