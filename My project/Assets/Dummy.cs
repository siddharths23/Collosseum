using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    private int maxHealth = 100;
    private int currentHealth;

    public BarController barController;

    // Start is called before the first frame update
    void Start()
    {
        barController.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    void OnCollisionEnter (Collision collision) {
        Debug.Log("collided");
        if (collision.gameObject.tag == "Weapon") {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage) {
        currentHealth -= damage;
        barController.setHealth(currentHealth); 
    }
}
