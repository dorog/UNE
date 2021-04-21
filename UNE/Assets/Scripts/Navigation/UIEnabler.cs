using UnityEngine;

public class UIEnabler : GameEnder
{
    public GameObject ui;
    public GameOverUI gameOverUI;

    public override void EndGame()
    {
        gameOverUI.HideUI();

        ui.SetActive(true);
    }
}
