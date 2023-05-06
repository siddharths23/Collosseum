using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManagement : NetworkBehaviour
{

    BarController healthBar;

    [SyncVar]
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.GetComponentInChildren<BarController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(health);
    }
}
