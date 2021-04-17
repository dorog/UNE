using UnityEngine;
using UnityEngine.UI;

public abstract class Participant : MonoBehaviour
{
    public DrawPile drawPile;
    public RoundManager roundManager;
    public RectTransform hand;

    public GameObject token;

    public GridLayoutGroup grid;

    public abstract void AddCard(Card card);

    public abstract void SelectCard();

    protected void SetGridSpacing(int cardInHand)
    {
        grid.spacing = new Vector2(CalculateGridSpacingX(cardInHand), 0);
    }

    private float CalculateGridSpacingX(int cardInHand)
    {
        float neededSpace = grid.cellSize.x * cardInHand;

        float gridSpacingX = (neededSpace - hand.sizeDelta.x) / (cardInHand - 1);

        if(gridSpacingX <= 0)
        {
            return 0;
        }

        return -gridSpacingX;
    }

    public void SetToken(bool state)
    {
        token.SetActive(state);
    }

    public void PullCard(uint amount)
    {
        drawPile.AddCard(this, amount);
    }

    public abstract void GameOver(Participant winner);

    public virtual void ResetHand()
    {
        foreach(Transform card in hand)
        {
            Destroy(card.gameObject);
        }

        SetToken(false);
    }
}
