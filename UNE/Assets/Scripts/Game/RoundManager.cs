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
        participants[actualParticipantIndex].SetToken(true);
        participants[actualParticipantIndex].SelectCard();
    }

    public bool SelectCard(Participant participant, Card card)
    {
        if(participant != participants[actualParticipantIndex])
        {
            return false;
        }

        if (discardPile.AddCard(card))
        {
            SelectNextParticipant();

            ActivateCardAbilities(card);

            participants[actualParticipantIndex].SelectCard();

            return true;
        }

        return false;
    }

    private void ActivateCardAbilities(Card card)
    {
        foreach (var ability in card.Abilities)
        {
            ability.TakeEffect(this);
        }
    }

    public bool PassRound(Participant participant)
    {
        if(participant != participants[actualParticipantIndex])
        {
            return false;
        }

        SelectNextParticipant();

        participants[actualParticipantIndex].SelectCard();

        return true;
    }

    public void SelectNextParticipant()
    {
        participants[actualParticipantIndex].SetToken(false);

        actualParticipantIndex++;
        if(actualParticipantIndex == participants.Length)
        {
            actualParticipantIndex = 0;
        }

        participants[actualParticipantIndex].SetToken(true);
    }

    public Participant GetNextParticipant()
    {
        if (actualParticipantIndex == participants.Length - 1)
        {
            return participants[0];
        }
        else
        {
            return participants[actualParticipantIndex + 1];
        }
    }

    public Participant GetActualParticipant()
    {
        return participants[actualParticipantIndex];
    }

    public void Won(Participant winner)
    {
        foreach(var participant in participants)
        {
            participant.GameOver(winner);
        }
    }
}