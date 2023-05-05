using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SkeletonAnimationController : NetworkBehaviour
{
    public NetworkAnimator animator;
    private string[] attackNames = {"Attack_1" , "Attack_2" , "Attack_3" , "Attack_4" , "Attack_5" , "Attack_6", 
                                    "Attack_7" , "Attack_8" , "Attack_9" , "Attack_10" , "Attack_11"};


    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {            
            //set the trigger to the a random number from 0 - 10
            animator.SetTrigger(attackNames[Random.Range(0 , 11)]);
        }
    }
}


