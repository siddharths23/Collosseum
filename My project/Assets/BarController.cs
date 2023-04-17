using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public Slider healthBar;
    public Slider staminaBar;

    public void setMaxHealth(int health) {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void setHealth(int health) {
        healthBar.value = health;
    }

    public void setMaxStamina(int stamina) {
        staminaBar.maxValue = stamina;
        staminaBar.value = stamina;
    }

    public void setStamina(int stamina) {
        staminaBar.value = stamina;
    }
}
