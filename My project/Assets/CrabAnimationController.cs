using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicCharacterController.Walkthrough.BasicMovement
{
    public class CrabAnimationController : MonoBehaviour
    {
        public MyCharacterController controller;
        public Animator animator;

        private bool tmp = true;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // Debug.Log(controller.moving);
            // Debug.Log(controller.moving && tmp);
            if (controller.moving && tmp) {
                tmp = false;
                animator.SetTrigger("Walk_Cycle_1");
            } 
            else if (!controller.moving) {
                tmp = true;
                animator.SetTrigger("Fight_Idle_1");
            }

            if (Input.GetMouseButtonDown(0))
            {
               animator.SetTrigger("Attack_1");
            }
        }
    }
}

