using UnityEngine;

public class UIDisabler : GameStarter
{
    public GameObject ui;
    public DrawPile drawPile;

    public override void StartGame()
    {
        ui.SetActive(false);

        drawPile.StartGame();
    }
}
