using UnityEngine;

public class UIEnabler : GameEnder
{
    public GameObject ui;

    public override void EndGame()
    {
        ui.SetActive(true);
    }
}
