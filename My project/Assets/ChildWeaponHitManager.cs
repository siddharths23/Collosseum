using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildWeaponHitManager : MonoBehaviour
{

    // GameObject root;
    WeaponHitManager weapon;
    string rootName;

    // Start is called before the first frame update
    void Start()
    {
        // root = this.transform.root;
        weapon = this.transform.root.GetComponent<WeaponHitManager>();
        rootName = this.transform.root.name;
    }

   void OnTriggerEnter(Collider collision) {
        Debug.Log("collided with child");
        if (collision.gameObject.layer == 11 && collision.gameObject.transform.root.name != rootName) {            
            //Make the target take damage
            weapon.hitTarget(collision.gameObject.transform.root.name);
        }    
    }
}
