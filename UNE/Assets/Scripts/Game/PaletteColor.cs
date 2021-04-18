using UnityEngine;
using UnityEngine.UI;

public class PaletteColor : MonoBehaviour
{
    public Player player;
    public Image image;

    public CardColor color;

    private void Start()
    {
        image.color = color.GetColor();
    }

    public void SetPlayerSelectedColor()
    {
        player.SetSelectedColor(image.color.GetCardColor());
    }
}
