using UnityEngine;

public class Table : MonoBehaviour
{
    public Participant[] participants;

    public DrawPile drawPile;
    public DiscardPile discardPile;
    public RoundManager roundManager;

    public void StartGame()
    {
        ResetParticipants();

        drawPile.Setup(participants);

        StartRoundManager();
    }

    private void StartRoundManager()
    {
        roundManager.Initialize(participants, discardPile);

        roundManager.StartGame();
    }

    private void ResetParticipants()
    {
        foreach (var participant in participants)
        {
            participant.ResetHand();
        }
    }
}
