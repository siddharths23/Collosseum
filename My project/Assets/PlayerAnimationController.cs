using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAnimationController : NetworkBehaviour
{
    public NetworkAnimator animator;

    public HitboxManager hitboxs;
    public bool canRoll;

    public string[] attackNames;
    public WeaponHitManager weapons;
    //attack Rate and nextAttackTime logic is from brackeys melee combat tutorial
    public float attackRate = 1f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {            
            //set the trigger to a random attack
            animator.SetTrigger(attackNames[Random.Range(0 , attackNames.Length)]);            
            
            nextAttackTime = Time.time + 1f / attackRate;

            //then enable and disable the hitboxs after certain times
            StartCoroutine(attack(0.25f, 0.5f));
        }

        if (canRoll && isLocalPlayer && Input.GetKey(KeyCode.Space)) {
            animator.SetTrigger("Rolling");
            StartCoroutine(hitboxs.invincibleForSeconds(0.5f));
        }
    }

    IEnumerator attack(float enableTime, float disableTime)
    {
        yield return new WaitForSeconds(enableTime);
        weapons.enableWeaponHitBox();

        yield return new WaitForSeconds(disableTime);
        weapons.disableWeaponHitBox();
    }

    public void Die()
    {
        animator.SetTrigger("Dead");
        hitboxs.disableHitboxs();
    }
}
