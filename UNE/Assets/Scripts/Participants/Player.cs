
public class Player : Participant
{
    public PlayerCard playerCard;
    public DrawPile drawPile;

    public GameOverUI gameOverUI;

    private int cardInHand = 0;

    public override void AddCard(Card card)
    {
        PlayerCard actualCard = Instantiate(playerCard, hand);
        actualCard.player = this;
        actualCard.roundManager = roundManager;
        actualCard.SetCard(card);

        cardInHand++;
    }

    public override void SelectCard() { }

    public void DrawCard()
    {
        drawPile.AddCard(this, 1);

        roundManager.PassRound(this);
    }

    public void RemoveCard()
    {
        cardInHand--;
        CheckCards();
    }

    private void CheckCards()
    {
        if(cardInHand == 0)
        {
            roundManager.Won(this);
        }
    }

    public override void GameOver(Participant winner)
    {
        gameOverUI.ShowUI(winner == this);
    }
}
