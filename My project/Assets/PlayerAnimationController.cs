using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAnimationController : NetworkBehaviour
{
    public NetworkAnimator animator;
    public string[] attackNames;


    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {            
            //set the trigger to the a random number from 0 - 10
            animator.SetTrigger(attackNames[Random.Range(0 , attackNames.Length)]);
        }
    }

    public void Die()
    {
        animator.SetTrigger("Dead");
    }
}
