using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public uint StartRoundCards;
    public Desk desk;

    public Participant[] participants;

    public DiscardPile discardPile;

    public RoundManager roundManager;

    private readonly List<Card> availableCards = new List<Card>();

    public void StartGame()
    {
        CheckSetup();

        InitializeGame();

        DealCards();

        SelectStartCard();

        StartRoundManager();
    }

    private void CheckSetup()
    {
        if(StartRoundCards * participants.Length > desk.CardsCount())
        {
            Debug.LogError("There is no enough card for the participants!");
        }
    }

    private void InitializeGame()
    {
        availableCards.Clear();

        foreach (var cardSet in desk.CardSets)
        {
            for(int i = 0; i < cardSet.Amount; i++)
            {
                availableCards.Add(cardSet.Card);
            }
        }
    }

    private void DealCards()
    {
        for(int roundIndex = 0; roundIndex < StartRoundCards; roundIndex++)
        {
            for(int playerIndex = 0; playerIndex < participants.Length; playerIndex++)
            {
                if(availableCards.Count > 0)
                {
                    int cardIndex = Random.Range(0, availableCards.Count);
                    participants[playerIndex].AddCard(availableCards[cardIndex]);

                    availableCards.RemoveAt(cardIndex);
                }
            }
        }
    }

    private void SelectStartCard()
    {
        List<Card> normalCards = availableCards.FindAll(x => x.CardType == CardType.Normal);

        if(normalCards.Count > 0)
        {
            int cardIndex = Random.Range(0, normalCards.Count);

            Card selectedCard = normalCards[cardIndex];

            discardPile.ShowFirstCard(selectedCard);

            int realIndex = availableCards.FindIndex(x => x == selectedCard);
            availableCards.RemoveAt(realIndex);
        }
        else
        {
            Debug.LogError("There is no enough card for start a game!");
        }
    }

    private void StartRoundManager()
    {
        roundManager.Initialize(participants, discardPile);

        roundManager.StartGame();
    }
}
