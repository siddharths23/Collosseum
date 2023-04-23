using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SkeletonMovementController : NetworkBehaviour
{
    public float speed = 30;
    Rigidbody rigidbody;
    public Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer) {
            rigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
            if(Mathf.Abs(rigidbody.velocity.magnitude) > 0.01f) {
                animator.SetBool("Moving", true);
                animator.SetFloat("Velocity X", rigidbody.velocity.x);
                animator.SetFloat("Velocity Z", rigidbody.velocity.z);
            } else {
                animator.SetBool("Moving", false);
            }
            // animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.magnitude));
            
        }
    }
}
