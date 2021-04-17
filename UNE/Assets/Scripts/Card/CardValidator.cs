using System.Collections.Generic;
using UnityEngine;

public class CardValidator : MonoBehaviour
{
    public static bool IsValidNextCard(Card nextCard, Card lastCard)
    {
        if(lastCard == null)
        {
            return true;
        }

        return lastCard.Color == nextCard.Color || lastCard.Id == nextCard.Id;
    }

    public static List<Card> GetAllValidNextCards(List<Card> cards, Card lastCard)
    {
        return cards.FindAll(nextCard => IsValidNextCard(nextCard, lastCard));
    }
}
