using System.Collections;

public class ChangeColor : CardAbility
{
    public override IEnumerator TakeEffect(RoundManager roundManager)
    {
        Participant actualParticipant = roundManager.GetActualParticipant();

        yield return actualParticipant.ChangeLastCardColor();
    }
}
