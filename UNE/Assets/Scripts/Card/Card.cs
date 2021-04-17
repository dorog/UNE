using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Color Color;
    public int Id;
    public string DisplayValue;

    public CardAbility[] Abilities;
}
