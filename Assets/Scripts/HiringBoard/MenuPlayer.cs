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
            UI.gameObject.SetActive(true);
            MenuServer.Instance.OnButtonClick += UpdateUI;
        }
    }

    public void PressButton(ChefButtonData data)
    {
        if (isLocalPlayer)
        {
            Debug.Log($"Button pressed by you");
            if (money >= data.cost)
            {
                money -= data.cost;
                CmdRequestBuy(data.id);
            }
            else
            {
                Debug.Log("You do not have enough money!");
            }
        }
    }

    [Command(requiresAuthority = false)]
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
