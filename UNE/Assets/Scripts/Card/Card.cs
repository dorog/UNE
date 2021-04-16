using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public CardType CardType;
    public Color Color;
    public uint Value; 
}
