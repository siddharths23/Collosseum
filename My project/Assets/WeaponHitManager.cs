using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WeaponHitManager : NetworkBehaviour
{
    public int weaponDamage;
    Collider hitbox;
    public NetworkManagerHW4 manager;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        hitbox = GetComponent<Collider>();
        manager = GameObject.Find("NetworkManager").GetComponent<NetworkManagerHW4>();
    }
    

    void OnCollisionEnter(Collision collision) {
        // Debug.Log("collided");
        if (collision.gameObject.layer == 11) {
            //Make the target take damage
            TakeDamage(collision.gameObject.transform.root.name, weaponDamage);
            Debug.Log("target: " + collision.gameObject.transform.root.name + " should take " + weaponDamage + " damage");  
        }
        
    }

    public void enableWeaponHitBox() {
        hitbox.enabled = true;
    }

    public void disableWeaponHitBox() {
        hitbox.enabled = false;
    }

    [Command(requiresAuthority = false)]
    public void TakeDamage(string name, int damage) {
        manager.TakeDamage(this.name, damage);
    }
}
