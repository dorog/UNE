using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    public VisibleCard lastDiscardedCard;

    private readonly List<Card> pile = new List<Card>();

    public void ShowFirstCard(Card card)
    {
        lastDiscardedCard.gameObject.SetActive(true);

        AddCard(card);
    }

    public bool AddCard(Card card)
    {
        if(CardValidator.IsValidNextCard(card, lastDiscardedCard.card))
        {
            pile.Add(card);

            lastDiscardedCard.SetCard(card);

            return true;
        }

        return false;
    }

    public List<Card> GetPile()
    {
        return pile;
    }

    public void ClearPile()
    {
        pile.Clear();
    }
}
