using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    public Transform hand;

    public abstract void AddCard(Card card);

    public abstract void ChoseCard();
}
