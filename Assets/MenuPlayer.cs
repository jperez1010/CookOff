using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MenuPlayer : NetworkBehaviour
{
    [SyncVar]
    public int cheffs_available = 4;
    public TMP_Text text;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending button press");
            ClickButton();
        }
        if (isLocalPlayer)
        {
            text.SetText(cheffs_available.ToString());
        }
    }

    [Command]
    void ClickButton()
    {
        Debug.Log("Button pressed");
        cheffs_available -= 1;
    }
}
