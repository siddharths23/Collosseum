using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CrabMovementController : NetworkBehaviour
{
    public float speed = 30;
    public Rigidbody rigidbody;
    public Animator animator;

    // Update is called once per frame
    void FixedUpdate()
        {
            if (isLocalPlayer) {
                rigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
                animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.magnitude));
            }
        }
}