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
    
    public override void OnStartServer()
    {
        chefs = "111";
    }

    [Command(requiresAuthority = false)]
    public void ClickButton(int id) 
    {
        char[] temp = chefs.ToCharArray();
        temp[id] = '0';
        chefs = temp.ArrayToString();

        menu.DeactivateButtonID(id);
    }
}
