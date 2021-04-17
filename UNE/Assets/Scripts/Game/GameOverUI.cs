using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Image background;
    public Color winColor;
    public Color loseColor;

    public Text playerResult;

    public void ShowUI(bool isPlayerWon)
    {
        background.color = isPlayerWon ? winColor : loseColor;
        playerResult.text = isPlayerWon ? "You win!" : "You lose!";

        background.gameObject.SetActive(true);
    }
}
