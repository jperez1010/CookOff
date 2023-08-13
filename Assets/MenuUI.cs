using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class MenuUI : NetworkBehaviour
{
    public static MenuUI menuUI;
    
    public Button[] buttons = new Button[3];
    public TMP_Text money;


    void Start()
    {
        menuUI = this;
    }

    public void PressButton(string data)
    {
        int buttonId;
        int cost;
        (buttonId, cost) = InterpretData(data);
        MenuPlayer.localPlayer.BuyChef(buttonId, cost);
    }

    [ClientRpc]
    public void DeactivateButton(int buttonId)
    {
        buttons[buttonId].interactable = false;
    }

    public (int, int) InterpretData(string data)
    {
        string[] dataset = data.Split(';');
        int buttonId = int.Parse(dataset[0]);
        int cost = int.Parse(dataset[1]);
        return (buttonId, cost);
    }

    public void UpdateMoney(int new_money)
    {
        money.text = new_money.ToString();
    }
}
