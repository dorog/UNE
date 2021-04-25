using UnityEngine;

public class PlayerCard : VisibleCard
{
    [Header("Player Card settings")]
    public Player player;
    public RoundManager roundManager;

    public void OnClick()
    {
        bool result = roundManager.SelectCard(player, card);
        if (result)
        {
            player.RemoveCard();

            Destroy(gameObject);
        }
    }
}
