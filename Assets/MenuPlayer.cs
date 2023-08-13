using UnityEngine;
using Mirror;

public class MenuPlayer : NetworkBehaviour
{
    [SyncVar]
    public int money;
    public Canvas UI;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer)
        {
            Debug.Log($"Player {this.netId} added as listener");
            MenuServer.Instance.OnButtonClick += UpdateUI;
        }
    }

    public void PressButton(ChefButtonData data)
    {
        if (money >= data.cost)
        {
            money -= data.cost;
            CmdRequestBuy(data.id);
        }
        else
        {
            Debug.Log("Tu eres pobre tu no tienes ifon");
        }
    }

    [Command]
    public void CmdRequestBuy(int chefId)
    {
        Debug.Log($"Sending Request for chef {chefId}");
        MenuServer.Instance.RequestBuy(chefId);
    }

    public void UpdateUI(int chefId)
    {
        ChefButtonData[] buttonData = UI.GetComponentsInChildren<ChefButtonData>();
        for (int i = 0; i < buttonData.Length; i++)
        {
            if (buttonData[i].id == chefId)
            {
                buttonData[i].DeactivateButton();
            }
        }
    }
}
