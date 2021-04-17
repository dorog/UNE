using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Participant
{
    public GameObject cardPlaceholder;

    public DrawPile drawPile;

    public DiscardPile discardPile;

    private readonly List<Card> cards = new List<Card>();

    public override void AddCard(Card card)
    {
        cards.Add(card);

        Instantiate(cardPlaceholder, hand);
    }

    public override void SelectCard()
    {
        StartCoroutine(nameof(AsyncSelectCard));
    }

    private IEnumerator AsyncSelectCard()
    {
        yield return new WaitForSeconds(3);

        List<Card> validNextCards = CardValidator.GetAllValidNextCards(cards, discardPile.lastDiscardedCard.card);
        if (validNextCards.Count == 0)
        {
            if (roundManager.PassRound(this))
            {
                drawPile.AddCard(this, 1);
            }
        }
        else
        {
            Card selectedCard = Select(validNextCards);
            if(roundManager.SelectCard(this, selectedCard))
            {
                Destroy(hand.GetChild(0).gameObject);

                int selectedCardIndex = cards.FindIndex(x => x == selectedCard);
                cards.RemoveAt(selectedCardIndex);

                CheckCardsState();
            }
            else
            {
                Debug.LogError("AI picked invalid card!");
            }
        }
    }

    private Card Select(List<Card> validNextCards)
    {
        return validNextCards[0];
    }

    private void CheckCardsState()
    {
        if(cards.Count == 0)
        {
            roundManager.Won(this);
        }
    }

    public override void GameOver(Participant winner) 
    {
        if (token.activeSelf)
        {
            StopCoroutine(nameof(AsyncSelectCard));
        }
    }

    public override void ResetHand()
    {
        base.ResetHand();
        cards.Clear();
    }
}
