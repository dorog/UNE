using UnityEngine;
using UnityEngine.UI;

public class VisibleCard : MonoBehaviour
{
    public Image background;

    [Header("Texts")]
    public Text middleText;
    public Text leftTopText;
    public Text rightBottomText;

    [Header("Icons")]
    public Image middleImage;
    public Image leftTopImage;
    public Image rightBottomImage;

    protected Card card;

    public void SetCard(Card card)
    {
        this.card = card;

        ChangeColor(card.Color.GetColor());
        middleText.text = card.MiddleValue;
        leftTopText.text = card.SideValue;
        rightBottomText.text = card.SideValue;

        if(card.MiddleIcon != null)
        {
            middleImage.sprite = card.MiddleIcon;
            middleImage.gameObject.SetActive(true);
        }
        else
        {
            middleImage.gameObject.SetActive(false);
        }

        if(card.SideIcon != null)
        {
            leftTopImage.sprite = card.SideIcon;
            leftTopImage.gameObject.SetActive(true);

            rightBottomImage.sprite = card.SideIcon;
            rightBottomImage.gameObject.SetActive(true);
        }
        else
        {
            leftTopImage.gameObject.SetActive(false);
            rightBottomImage.gameObject.SetActive(false);
        }
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
        lastCard.MiddleValue = card.MiddleValue;
        lastCard.Color = background.color.GetCardColor();

        return lastCard;
    }
}
