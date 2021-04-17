using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int actualParticipantIndex;

    private Participant[] participants;
    private DiscardPile discardPile;

    public void Initialize(Participant[] participants, DiscardPile discardPile)
    {
        if(participants == null || participants.Length == 0)
        {
            Debug.LogError("There is no participant!");
            return;
        }

        actualParticipantIndex = 0;
        this.participants = participants;
        this.discardPile = discardPile;
    }

    public void StartGame()
    {
        participants[actualParticipantIndex].SelectCard();
    }

    public bool SelectCard(Participant participant, Card card)
    {
        if(participant != participants[actualParticipantIndex])
        {
            return false;
        }

        actualParticipantIndex++;
        discardPile.AddCard(card);

        participants[actualParticipantIndex].SelectCard();

        return true;
    }
}
