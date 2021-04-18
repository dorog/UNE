
public class PullCards : CardAbility
{
    public uint amount;

    public override void TakeEffect(RoundManager roundManager)
    {
        Participant nextParticipant = roundManager.GetNextActualParticipant();
        nextParticipant.PullCard(amount);
    }
}
