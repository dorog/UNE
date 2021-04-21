using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public CardColor Color;
    public string Id;
    public string DisplayValue;

    public CardAbility[] Abilities;
}
