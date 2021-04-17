using System.Collections.Generic;
using UnityEngine;

public class CardValidator : MonoBehaviour
{
    public static bool IsValidNextCard(Card nextCard, Card lastCard)
    {
        return lastCard.Color == nextCard.Color || lastCard.Value == nextCard.Value;
    }

    public static List<Card> GetAllValidNextCards(List<Card> cards, Card lastCard)
    {
        return cards.FindAll(nextCard => IsValidNextCard(nextCard, lastCard));
    }
}
