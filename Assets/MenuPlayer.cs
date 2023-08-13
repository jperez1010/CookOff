using Mirror;

public class MenuPlayer : NetworkBehaviour
{
    public static MenuPlayer localPlayer;
    
    public int money;


    public void Start()
    {
        if (isLocalPlayer)
        {
            localPlayer = this;
            MenuUI.menuUI.UpdateMoney(money);
        }
    }

    public void BuyChef(int buttonId, int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            MenuServer.menuServer.UpdateChefs(buttonId);
            MenuUI.menuUI.UpdateMoney(money);
        }
    }
}
