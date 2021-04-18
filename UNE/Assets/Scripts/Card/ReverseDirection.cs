
public class ReverseDirection : CardAbility
{
    public override void TakeEffect(RoundManager roundManager)
    {
        roundManager.ChangeTurnDirection();
    }
}
