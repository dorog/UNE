using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    public DrawPile drawPile;
    public RoundManager roundManager;
    public Transform hand;

    public GameObject token;

    protected bool SkipNextTurn = false;

    public abstract void AddCard(Card card);

    public abstract void SelectCard();

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
