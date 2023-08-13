using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class MenuServer : NetworkBehaviour
{
    [SyncVar]
    public string chefs;

    public MenuUI menu;
    public TMP_Text text;
    
    public override void OnStartServer()
    {
        chefs = "111";
    }

    [Command(requiresAuthority = false)]
    public void UpdateButton(string data) 
    {
        string[] gungan = data.Split(';');
        int buttonId = int.Parse(gungan[0]);
        int cost = int.Parse(gungan[1]);
        Debug.Log(cost);
        Debug.Log(buttonId);
        MenuPlayer player = NetworkServer.localConnection.identity.GetComponent<MenuPlayer>();
        if (player.money >= cost)
        {
            player.money -= cost;
            text.text = player.money.ToString();
            char[] temp = chefs.ToCharArray();
            temp[buttonId] = '0';
            chefs = temp.ArrayToString();
            
            menu.DeactivateButtonID(buttonId);
        }

    }
}
