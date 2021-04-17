using UnityEngine;
using UnityEngine.UI;

public class VisibleCard : MonoBehaviour
{
    public Image background;
    public Text number;

    public Card card;

    public void SetCard(Card card)
    {
        this.card = card;

        background.color = card.Color;
        number.text = card.DisplayValue;
    }
}
