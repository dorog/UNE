
public class PlayerCard : VisibleCard
{
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
