using System.Collections;

public class ReverseDirection : CardAbility
{
    public override IEnumerator TakeEffect(RoundManager roundManager)
    {
        roundManager.ChangeTurnDirection();

        yield return null;
    }
}
