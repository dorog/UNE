using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    public RoundManager roundManager;
    public Transform hand;

    public GameObject token;

    public abstract void AddCard(Card card);

    public abstract void SelectCard();

    public void SetToken(bool state)
    {
        token.SetActive(state);
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
