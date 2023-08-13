using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MenuPlayer : NetworkBehaviour
{
    public delegate void OnPlayerPressX();

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
    }

    [Command(requiresAuthority = false)]
    void ClickButton()
    {
        Debug.Log("Button pressed");
    }
}
