using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BuyLobbyNetworkManager : NetworkManager
{
    public ArrayList addresses = new ArrayList();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        addresses.Add(conn.address);
    }

}
