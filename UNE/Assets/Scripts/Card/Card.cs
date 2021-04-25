using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public CardColor Color;
    public string Id;
    public string MiddleValue;
    public string SideValue;
    public Sprite MiddleIcon;
    public Sprite SideIcon;

    public CardAbility[] Abilities;
}
