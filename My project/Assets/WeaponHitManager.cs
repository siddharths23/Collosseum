using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitManager : MonoBehaviour
{
    public int weaponDamage;
    Collider hitbox;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        hitbox = GetComponent<Collider>();
    }
    

    void OnCollisionEnter(Collision collision) {
        // Debug.Log("collided");
        if (collision.gameObject.layer == 11) {
            //Make the target take damage
            collision.gameObject.GetComponent<HitboxManager>().TakeDamage(weaponDamage);
            Debug.Log("target: " + collision.gameObject.name + " should take " + weaponDamage + " damage");  
        }
        
    }

    public void enableWeaponHitBox() {
        hitbox.enabled = true;
    }

    public void disableWeaponHitBox() {
        hitbox.enabled = false;
    }
}
