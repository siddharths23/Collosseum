using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WeaponHitManager : NetworkBehaviour
{
    public int weaponDamage;
    public Collider[] hitbox;
    public NetworkManagerHW4 manager;

    void Start()
    {  
        manager = GameObject.Find("NetworkManager").GetComponent<NetworkManagerHW4>();
        disableWeaponHitBox();
    }
    
    public void hitTarget(string name) {
        Debug.Log("target: " + name + " should take " + weaponDamage + " damage"); 
        TakeDamage(name, weaponDamage);
    }

    public void enableWeaponHitBox() {
        foreach (Collider box in hitbox) {
            box.enabled = true;
        }  
    }

    public void disableWeaponHitBox() {
        foreach (Collider box in hitbox) {
            box.enabled = false;
        }        
    }

    [Command(requiresAuthority = false)]
    public void TakeDamage(string name, int damage) {
        manager.TakeDamage(name, damage);
    }
}
