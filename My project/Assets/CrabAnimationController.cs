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
        private bool animated = false;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!animated) {
                animated = false;
                animator.SetTrigger("Fight_Idle_1");
            }

            // Debug.Log(controller.moving);
            // Debug.Log(controller.moving && tmp);
            if (controller.moving && tmp) {
                tmp = false;
                animated = true;
                animator.SetTrigger("Walk_Cycle_1");
            } 

            if (Input.GetMouseButtonDown(0))
            {
                animated = true;
                animator.SetTrigger("Attack_1");
            }
        }
    }
}

