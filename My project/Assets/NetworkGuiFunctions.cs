using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkGuiFunctions : MonoBehaviour
{
    NetworkManager manager;
    public GameObject serverSelection;
    public GameObject addressinput;
    public GameObject characterSelection;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void ServerClient() {
        Debug.Log("Clicked a button");
        if (!NetworkClient.active) {
            manager.StartHost();            
        }
    }

    public void Client() {
        if (!NetworkClient.active) {
            manager.StartClient();
            SetAddress(addressinput.GetComponent<InputField>().text);
            NetworkClient.Ready();
            if (NetworkClient.localPlayer == null)
            {
                NetworkClient.AddPlayer();                        
            }
        }
    }

    public void SetAddress(string address) {
        manager.networkAddress = address;
    }

    // public void SelectCrab() {
    //     NetworkClient.Ready();
    //     if (NetworkClient.localPlayer == null)
    //     {
    //         join(NetworkClient.connection,0);
    //     }
    // }

    // public void Select2Handed() {
    //     NetworkClient.Ready();
    //     if (NetworkClient.localPlayer == null)
    //     {
    //         join(NetworkClient.connection,1);
    //     }
    // }

    // public void SelectShield() {
    //     NetworkClient.Ready();
    //     if (NetworkClient.localPlayer == null)
    //     {
    //         join(NetworkClient.connection,2);
    //     }
    // }

    // public void SelectMage() {
    //     NetworkClient.Ready();
    //     if (NetworkClient.localPlayer == null)
    //     {
    //         join(NetworkClient.connection,3);
    //     }
    // }

    // [Command(requiresAuthority = false)]
    // void join (NetworkConnectionToClient conn, int character) {
    //     manager.join(conn, character);
    // }
}
