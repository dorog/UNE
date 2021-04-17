using UnityEngine;

[CreateAssetMenu(fileName = "new Desk", menuName = "Desk")]
public class Desk : ScriptableObject
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
