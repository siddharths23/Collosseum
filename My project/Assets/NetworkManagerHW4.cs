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
    public Transform mageSpawn;
    public Transform shieldSpawn;
    
    private Dictionary<string, int> playerHealth = new Dictionary<string, int>();
    private Dictionary<string, PlayerManagement> playerBar = new Dictionary<string, PlayerManagement>();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("Player " + numPlayers + " joined.");
        // add player at correct spawn position
        // Transform start = numPlayers == 0 ? bossSpawn : playerSpawn;
        // playerPrefab = numPlayers == 0 ? spawnPrefabs.Find(prefab => prefab.name == "CrabBoss") : spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");

        Transform start = bossSpawn;
        GameObject playerPrefab;

        if (numPlayers == 0)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");
        }
        else if (numPlayers == 1)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "mage_Simple");
        }
        else
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarrior");
        }


        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        //Should instantiate health a different way
        playerHealth[player.name] = 100;
        playerBar[player.name] = player.GetComponentInChildren<PlayerManagement>();


    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Player Left.");
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }

    public void TakeDamage(string name, int damage) {
        //update the health
        playerHealth[name] = playerHealth[name] - damage;
        Debug.Log("Player " + name + "now has " + playerHealth[name] + "health.");

        //send new health to all clients
        playerBar[name].health = playerHealth[name];
    }

}

