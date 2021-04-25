using System.Collections;

public class SkipTurn : CardAbility
{
    public override IEnumerator TakeEffect(RoundManager roundManager)
    {
        roundManager.SkipNextParticipant();

        yield return null;
    }
}
