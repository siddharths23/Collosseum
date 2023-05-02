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

    void onTriggerEnter(Collider collision) {
        Debug.Log("triggered");

        // if (collision.gameObject.layer == 10) {
            //Make the target take damage
            TakeDamage(this.transform.root.name, 10);
            Debug.Log("target: " + this.transform.root.name + " should take " + 10 + " damage");  
        // }
    }

    [Command(requiresAuthority = false)]
    public void TakeDamage(string name, int damage) {
        manager.TakeDamage(name, damage);
    }
}
