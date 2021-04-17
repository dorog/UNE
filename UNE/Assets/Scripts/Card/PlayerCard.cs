using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public Image background;
    public Text number;

    public Card card;
    public Player player;
    public RoundManager roundManager;

    public void SetCard(Card card)
    {
        this.card = card;

        background.color = card.Color;
        number.text = card.Value.ToString();
    }

    public void OnClick()
    {
        bool result = roundManager.SelectCard(player, card);
        if (result)
        {
            Destroy(gameObject);

            player.RemoveCard();
        }
    }
}
