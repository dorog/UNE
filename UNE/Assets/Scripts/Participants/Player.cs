using UnityEngine;

public class Player : Participant
{
    public PlayerCard playerCard;

    public override void AddCard(Card card)
    {
        PlayerCard actualCard = Instantiate(playerCard, hand);
        actualCard.SetCard(card);
    }

    public override void ChoseCard()
    {
        throw new System.NotImplementedException();
    }
}
