using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public Image background;
    public Text number;

    public void SetCard(Card card)
    {
        background.color = card.Color;
        number.text = card.Value.ToString();
    }
}
