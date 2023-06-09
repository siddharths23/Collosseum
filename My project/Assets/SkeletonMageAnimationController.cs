using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SkeletonMageAnimationController : NetworkBehaviour
{
   
    public NetworkAnimator animator;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {            
            //set the trigger to the a random number from 0 - 10
            animator.SetTrigger("Attack_1");
        }
    }

    void Die()
    {
        animator.SetTrigger("Dead");
    }
}
