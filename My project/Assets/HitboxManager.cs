using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HitboxManager : NetworkBehaviour
{
    public NetworkManagerHW4 manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("NetworkManager").GetComponent<NetworkManagerHW4>();
    }

    [Command]
    public void TakeDamage(int damage) {
        manager.TakeDamage(this.name, damage);
    }
}
