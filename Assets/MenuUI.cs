using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuUI : NetworkBehaviour
{
    public Button[] buttons = new Button[3];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ClientRpc]
    public void DeactivateButtonID(int id)
    {
        buttons[id].interactable = false;
    }
}
