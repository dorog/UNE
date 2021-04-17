using System.Collections.Generic;
using UnityEngine;

public class AI : Participant
{
    public GameObject cardPlaceholder;

    private readonly List<Card> cards = new List<Card>();

    public override void AddCard(Card card)
    {
        cards.Add(card);

        Instantiate(cardPlaceholder, hand);
    }

    public override void ChoseCard()
    {
        throw new System.NotImplementedException();
    }
}
