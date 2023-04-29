using UnityEngine;
using Mirror;
using System.Collections.Generic;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
[AddComponentMenu("")]
public class NetworkManagerHW4 : NetworkManager
{
    public Transform bossSpawn;
    public Transform playerSpawn;
    
    private Dictionary<string, int> playerHealth = new Dictionary<string, int>();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("Player " + numPlayers + " joined.");
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? bossSpawn : playerSpawn;
        playerPrefab = numPlayers == 0 ? spawnPrefabs.Find(prefab => prefab.name == "CrabBoss") : spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        //Should instantiate health a different way
        playerHealth[player.name] = 100;
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Player Left.");
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }

    public void TakeDamage(string name, int damage) {
        playerHealth[name] = playerHealth[name] - damage;
        Debug.Log("Player " + name + "now has " + playerHealth[name] + "health.");
    }
}

