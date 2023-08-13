using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class MenuServer : NetworkBehaviour
{
    [SyncVar]
    public int cheffs_left;
    public TMP_Text text;

    public Button button;

    [SyncVar]
    public int r;
    [SyncVar]
    public int g;
    [SyncVar]
    public int b; 
    
    public override void OnStartServer()
    {
        cheffs_left = 5;
        r = (int) Random.Range(0, 256);
        g = (int) Random.Range(0, 256);
        b = (int) Random.Range(0, 256);
    }

    public void ClickButton() 
    {
        
        r = (int)Random.Range(0, 256);
        g = (int)Random.Range(0, 256);
        b = (int)Random.Range(0, 256);
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending button press");
            ClickButton();
        }
    }

}
