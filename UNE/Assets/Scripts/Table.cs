using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public uint StartRoundCards;
    public Desk desk;

    public Participant[] participants;

    private readonly List<Card> availableCards = new List<Card>();

    public void StartGame()
    {
        CheckSetup();

        InitializeGame();

        DealCards();
    }

    private void CheckSetup()
    {
        if(StartRoundCards * participants.Length > desk.CardsCount())
        {
            Debug.LogError("There is no enough card for the players!");
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
}
