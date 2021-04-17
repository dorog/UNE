
public class SkipTurn : CardAbility
{
    public override void TakeEffect(RoundManager roundManager)
    {
        roundManager.SelectNextParticipant();
    }
}
