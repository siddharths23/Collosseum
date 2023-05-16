using UnityEngine;
using Mirror;
using System.Collections;
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

    public UIManager uiManager;
    
    private Dictionary<string, int> playerHealth = new Dictionary<string, int>();
    private Dictionary<string, PlayerManagement> playerBar = new Dictionary<string, PlayerManagement>();
    private List<string> alive = new List<string>();
    private List<string> playerList = new List<string>();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("Player " + numPlayers + " joined.");
        // add player at correct spawn position
        // Transform start = numPlayers == 0 ? bossSpawn : playerSpawn;
        // playerPrefab = numPlayers == 0 ? spawnPrefabs.Find(prefab => prefab.name == "CrabBoss") : spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");

        Transform start;
        GameObject playerPrefab;

        if (numPlayers == 1)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "CrabBoss");
            start = bossSpawn;
        }
        else if (numPlayers == 0)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");
            start = playerSpawn;
        }
        else if (numPlayers == 2)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "mage_Simple");
            start = mageSpawn;
        }
        else if (numPlayers == 3)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarrior");
            start = shieldSpawn;
        }
        else 
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "CrabBoss");
            start = bossSpawn;
        }


        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        //Should instantiate health a different way
        playerHealth[player.name] = 100;
        playerBar[player.name] = player.GetComponent<PlayerManagement>();
        
        alive.Add(player.name);
        playerList.Add(player.name);
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

        if (playerHealth[name] < 1) {
            playerBar[name].isDead = true;
            alive.Remove(name);

            StartCoroutine(uiManager.ShowMessageForSeconds("Player " + name + " has been eliminated!", 4f));

            if (alive.Count == 1) 
            {                
                Debug.Log("Player " + alive[0] + " wins.");

                StartCoroutine(WaitAndShowWinnerMessage(5f, "Player " + alive[0] + " wins!"));

                StartCoroutine(despawnPlayersAfterSeconds(6f));
            }
        }
    }

    IEnumerator despawnPlayersAfterSeconds(float time) {
        yield return new WaitForSeconds(time);
        foreach (string player in playerList) {
            GameObject loser = GameObject.Find(player);
            Destroy(loser);
        }
    }

    IEnumerator WaitAndShowWinnerMessage(float waitTime, string message)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(uiManager.ShowMessageForSeconds(message, 5f));
    }

    public void join(NetworkConnectionToClient conn, int character) {
        Transform start;
        GameObject playerPrefab;

        if (character == 0)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "CrabBoss");
            start = bossSpawn;
        }
        else if (character == 1)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarriorTwoHandedWeaponSimple");
            start = playerSpawn;
        }
        else if (character == 2)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "mage_Simple");
            start = mageSpawn;
        }
        else if (character == 3)
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "SkeletonWarrior");
            start = shieldSpawn;
        }
        else 
        {
            playerPrefab = spawnPrefabs.Find(prefab => prefab.name == "CrabBoss");
            start = bossSpawn;
        }


        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        //Should instantiate health a different way
        playerHealth[player.name] = 100;
        playerBar[player.name] = player.GetComponent<PlayerManagement>();
        
        alive.Add(player.name);
        playerList.Add(player.name);
    }

}

