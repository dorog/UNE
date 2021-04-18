using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CardColor
{
    Black, Blue, Green, Red, Yellow
}

public static class CardColorExtension
{
    private static readonly List<ColorPair> ColorPairs = new List<ColorPair>()
    {
        new ColorPair() { CardColor = CardColor.Black, Color = Color.black },
        new ColorPair() { CardColor = CardColor.Blue, Color = Color.blue },
        new ColorPair() { CardColor = CardColor.Green, Color = Color.green },
        new ColorPair() { CardColor = CardColor.Red, Color = Color.red },
        new ColorPair() { CardColor = CardColor.Yellow, Color = Color.yellow },
    };

    public static Color GetColor(this CardColor cardColor)
    {
        return ColorPairs.FirstOrDefault(x => cardColor == x.CardColor).Color;
    }

    public static CardColor GetCardColor(this Color color)
    {
        return ColorPairs.FirstOrDefault(x => color == x.Color).CardColor;
    }
}
