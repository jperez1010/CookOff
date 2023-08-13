using Mirror;
using TMPro;

public class MenuServer : NetworkBehaviour
{
    public static MenuServer menuServer;
    
    [SyncVar]
    public string chefs;
    
    public override void OnStartServer()
    {
        menuServer = this;
        chefs = "111";
    }

    [Command(requiresAuthority = false)]
    public void UpdateChefs(int buttonId) 
    {
        char[] temp = chefs.ToCharArray();
        temp[buttonId] = '0';
        chefs = temp.ArrayToString();
        MenuUI.menuUI.DeactivateButton(buttonId);
    }
}