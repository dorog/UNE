using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int actualParticipantIndex;

    private Participant[] participants;
    private DiscardPile discardPile;

    private bool isClockWise = true;

    public RectTransform direction;

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
            ActivateCardAbilities(card);

            SelectNextParticipant();

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

        actualParticipantIndex = GetNextParticipantIndex();

        participants[actualParticipantIndex].SetToken(true);
    }

    public Participant GetNextActualParticipant()
    {
        return participants[GetNextParticipantIndex()];
    }

    private int GetNextParticipantIndex()
    {
        int nextParticipantIndex = actualParticipantIndex + 1 * (isClockWise ? 1 : -1);
        if (nextParticipantIndex == participants.Length)
        {
            return 0;
        }
        else if(nextParticipantIndex == -1)
        {
            return participants.Length - 1;
        }

        return nextParticipantIndex;
    }

    public void ChangeTurnDirection()
    {
        isClockWise = !isClockWise;

        direction.rotation *= Quaternion.Euler(180f, 0f, 0f);
    }

    public void Won(Participant winner)
    {
        foreach(var participant in participants)
        {
            participant.GameOver(winner);
        }
    }

    public void GameOver()
    {
        Won(participants[actualParticipantIndex]);
    }
}