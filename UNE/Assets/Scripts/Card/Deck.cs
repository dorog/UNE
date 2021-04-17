using UnityEngine;

[CreateAssetMenu(fileName = "new Deck", menuName = "Deck")]
public class Deck : ScriptableObject
{
    public CardSet[] CardSets;

    public int CardsCount()
    {
        int count = 0;
        foreach(var cardSet in CardSets)
        {
            count += cardSet.Amount;
        }

        return count;
    }
}
