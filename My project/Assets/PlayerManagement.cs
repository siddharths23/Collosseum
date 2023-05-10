using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManagement : NetworkBehaviour
{

    BarController healthBar;
    PlayerAnimationController animationController;
    PlayerMovementController movementController;


    [SyncVar]
    public int health;
    [SyncVar]
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.GetComponentInChildren<BarController>();
        animationController = this.GetComponent<PlayerAnimationController>();
        movementController = this.GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(health);
        if(isDead) {
            Die();
        }
    }

    public void Die() 
    {
        animationController.Die();
        animationController.enabled = false;
        movementController.enabled = false;
    }    
}
