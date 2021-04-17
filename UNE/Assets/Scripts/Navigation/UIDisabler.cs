using UnityEngine;

public class UIDisabler : GameStarter
{
    public GameObject ui;
    public Table table;

    public override void StartGame()
    {
        ui.SetActive(false);

        table.StartGame();
    }
}
