using System.Collections;
using UnityEngine;

public class Player : Participant
{
    public PlayerCard playerCard;

    public GameOverUI gameOverUI;

    private int cardInHand = 0;

    public GameObject palette;
    private bool colorSelected = false; 
    private CardColor selectedColor = CardColor.Black;

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

            palette.SetActive(false);
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

        palette.SetActive(false);
    }

    protected override IEnumerator SelectColor()
    {
        palette.SetActive(true);

        while (!colorSelected) 
        {
            yield return null;
        }
    }

    protected override CardColor GetSelectedColor()
    {
        colorSelected = false;
        return selectedColor;
    }

    public void SetSelectedColor(CardColor color)
    {
        selectedColor = color;
        colorSelected = true;

        palette.SetActive(false);
    }
}
