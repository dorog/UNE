using UnityEngine;

public class UIDisabler : GameStarter
{
    public GameObject ui;

    public override void StartGame()
    {
        ui.SetActive(false);
    }
}
