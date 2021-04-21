using System.Collections;
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

        SetGridSpacing(cards.Count);
    }

    public override void SelectCard()
    {
        List<Card> validNextCards = CardValidator.GetAllValidNextCards(cards, discardPile.lastDiscardedCard.GetCard());
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
            if (roundManager.SelectCard(this, selectedCard))
            {
                Destroy(hand.GetChild(0).gameObject);

                int selectedCardIndex = cards.FindIndex(x => x == selectedCard);
                cards.RemoveAt(selectedCardIndex);

                CheckCardsState();

                SetGridSpacing(cards.Count);
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
        if (cards.Count == 0)
        {
            roundManager.Won(this);
        }
    }

    public override void GameOver(Participant winner) { }

    public override void ResetHand()
    {
        base.ResetHand();
        cards.Clear();
    }

    protected override IEnumerator SelectColor()
    {
        yield return null;
    }

    protected override CardColor GetSelectedColor()
    {
        Dictionary<CardColor, int> cardsByColor = CountCardsByColor();

        int maxCardInGroup = 0;
        CardColor selectedColor = CardColor.Black;
        foreach (var group in cardsByColor)
        {
            if (maxCardInGroup < group.Value)
            {
                selectedColor = group.Key;
            }
        }

        if(selectedColor == CardColor.Black)
        {
            return GetRandomCardColor();
        }

        return selectedColor;
    }

    private Dictionary<CardColor, int> CountCardsByColor()
    {
        Dictionary<CardColor, int> cardsByColor = new Dictionary<CardColor, int>();

        foreach (var card in cards)
        {
            if (cardsByColor.ContainsKey(card.Color))
            {
                cardsByColor[card.Color]++;
            }
            else
            {
                cardsByColor.Add(card.Color, 1);
            }
        }

        return cardsByColor;
    }

    private CardColor GetRandomCardColor()
    {
        CardColor[] realColors = { CardColor.Blue, CardColor.Green, CardColor.Red, CardColor.Yellow };

        int selectedRandomColorIndex = Random.Range(0, realColors.Length);
        return realColors[selectedRandomColorIndex];
    }
}
