﻿using System.Collections.Generic;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public uint StartRoundCards;
    public Desk desk;

    public DiscardPile discardPile;

    private readonly List<Card> availableCards = new List<Card>();

    public void Setup(Participant[] participants)
    {
        CheckSetup(participants);

        InitializeGame();

        DealCards(participants);

        SelectStartCard();
    }

    private void CheckSetup(Participant[] participants)
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

    private void DealCards(Participant[] participants)
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
        if(availableCards.Count > 0)
        {
            int cardIndex = Random.Range(0, availableCards.Count);

            Card selectedCard = availableCards[cardIndex];

            discardPile.ShowFirstCard(selectedCard);

            int realIndex = availableCards.FindIndex(x => x == selectedCard);
            availableCards.RemoveAt(realIndex);
        }
        else
        {
            Debug.LogError("There is no enough card for start a game!");
        }
    }

    public void AddCard(Participant participant, uint amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if (availableCards.Count == 0)
            {
                Shuffle();
            }

            int cardIndex = Random.Range(0, availableCards.Count);
            participant.AddCard(availableCards[cardIndex]);

            availableCards.RemoveAt(cardIndex);
        }
    }

    private void Shuffle()
    {
        availableCards.AddRange(discardPile.GetPile());

        discardPile.ClearPile();
    }
}
