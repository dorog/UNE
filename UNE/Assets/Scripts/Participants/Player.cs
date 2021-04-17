using UnityEngine;

public class Player : Participant
{
    public PlayerCard playerCard;

    public GameOverUI gameOverUI;

    private int cardInHand = 0;

    public override void AddCard(Card card)
    {
        PlayerCard actualCard = Instantiate(playerCard, hand);
        actualCard.player = this;
        actualCard.roundManager = roundManager;
        actualCard.SetCard(card);

        cardInHand++;

        SetGridSpacing(cardInHand);
    }

    public override void SelectCard() { }

    public void DrawCard()
    {
        if (roundManager.PassRound(this))
        {
            drawPile.AddCard(this, 1);
        }
    }

    public void RemoveCard()
    {
        cardInHand--;

        CheckCards();

        SetGridSpacing(cardInHand);
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

    public override void ResetHand()
    {
        base.ResetHand();
        cardInHand = 0;
    }
}
