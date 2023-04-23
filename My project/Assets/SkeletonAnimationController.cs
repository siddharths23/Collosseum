using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SkeletonAnimationController : NetworkBehaviour
{
    public NetworkAnimator animator;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }
}


