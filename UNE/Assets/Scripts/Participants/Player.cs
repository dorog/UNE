
public class Player : Participant
{
    public PlayerCard playerCard;

    public override void AddCard(Card card)
    {
        PlayerCard actualCard = Instantiate(playerCard, hand);
        actualCard.owner = this;
        actualCard.roundManager = roundManager;
        actualCard.SetCard(card);
    }

    public override void SelectCard()
    {

    }
}
