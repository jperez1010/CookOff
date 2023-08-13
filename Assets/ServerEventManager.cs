using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerEventManager : NetworkBehaviour
{
    public delegate void ClickButton();
    public static event ClickButton OnButtonClick;

    // Update is called once per frame
    void Update()
    {
        
    }
}
