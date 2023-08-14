using Mirror;
using UnityEngine;
using TMPro;

public class MenuServer : NetworkBehaviour
{
    public static MenuServer Instance;

    public delegate void ClickButton(int id);
    public event ClickButton OnButtonClick;

    [SyncVar]
    public string chefs;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            chefs = "111";
        }
        else
        {
            Destroy(this);
        }
    }

    [ClientRpc]
    public void UpdateUI(int id)
    {
        Debug.Log("Letting clients know to update");
        OnButtonClick?.Invoke(id);
    }

    public void RequestBuy(int buttonId) 
    {
        Debug.Log($"Request recieved for {buttonId}");
        char[] temp = chefs.ToCharArray();
        temp[buttonId] = '0';
        chefs = temp.ArrayToString();
        UpdateUI(buttonId);
    }
}