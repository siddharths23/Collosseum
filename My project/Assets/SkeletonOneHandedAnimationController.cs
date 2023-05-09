using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SkeletonOneHandedAnimationController : NetworkBehaviour
{
    public NetworkAnimator animator;
    private string[] attackNames = {"Attack_1" , "Attack_2" , "Attack_3"};


    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {            
            //set the trigger to the a random number from 0 - 2
            animator.SetTrigger(attackNames[Random.Range(0 , 3)]);
        }
    }
}

