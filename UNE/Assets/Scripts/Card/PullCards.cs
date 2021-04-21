using System.Collections;

public class PullCards : CardAbility
{
    public uint amount;

    public override IEnumerator TakeEffect(RoundManager roundManager)
    {
        Participant nextParticipant = roundManager.GetNextParticipant();
        nextParticipant.PullCard(amount);

        yield return null;
    }
}
