using System.Collections;

public class SkipTurn : CardAbility
{
    public override IEnumerator TakeEffect(RoundManager roundManager)
    {
        roundManager.SelectNextParticipant();

        yield return null;
    }
}
