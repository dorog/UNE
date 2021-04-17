using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    public RoundManager roundManager;
    public Transform hand;

    public abstract void AddCard(Card card);

    public abstract void SelectCard();
}
