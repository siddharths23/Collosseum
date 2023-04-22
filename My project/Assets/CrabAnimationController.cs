using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CrabAnimationController : NetworkBehaviour
{
    public Animator animator;

    // private bool tmp = true;
    // private bool animated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (!animated) {
        //     animated = false;
        //     animator.SetTrigger("Fight_Idle_1");
        // }

        // // Debug.Log(controller.moving);
        // // Debug.Log(controller.moving && tmp);
        // bool moving = ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0));
        // if (moving && tmp) {
        //     tmp = false;
        //     animated = true;
        //     animator.SetTrigger("Walk_Cycle_1");
        // } 

        if (Input.GetMouseButtonDown(0))
        {
            // animated = true;
            animator.SetTrigger("Attack_1");
        }
    }
}


