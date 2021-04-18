using UnityEngine;
using UnityEngine.UI;

public class VisibleCard : MonoBehaviour
{
    public Image background;
    public Text number;

    protected Card card;

    public void SetCard(Card card)
    {
        this.card = card;

        ChangeColor(card.Color.GetColor());
        number.text = card.DisplayValue;
    }

    public void ChangeColor(Color color)
    {
        background.color = color;
    }

    public Card GetCard()
    {
        if(card == null)
        {
            return null;
        }

        Card lastCard = ScriptableObject.CreateInstance<Card>();

        lastCard.Id = card.Id;
        lastCard.DisplayValue = card.DisplayValue;
        lastCard.Color = background.color.GetCardColor();

        return lastCard;
    }
}
