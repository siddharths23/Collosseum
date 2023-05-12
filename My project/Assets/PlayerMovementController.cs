using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementController : NetworkBehaviour
{
    public float speed = 30;
    public float rotSpeed = 60;
    public float rollForce = 10000;
    Rigidbody myRigidBody;
    public Animator animator;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 move = myRigidBody.rotation * (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime);
            myRigidBody.velocity = move;
            animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody>().velocity.magnitude));

            float xRot = Input.GetAxisRaw("Mouse X");
            // float yRot = Input.GetAxisRaw("Mouse Y");

            Vector3 rotVector = new Vector3(0f, xRot, 0f);

            Quaternion deltaRot = Quaternion.Euler(rotSpeed * rotVector * Time.fixedDeltaTime);
            myRigidBody.MoveRotation(myRigidBody.rotation * deltaRot);
        }
    }
    
    // public void roll() {
    //     myRigidBody.velocity += (myRigidBody.rotation * (new Vector3(1,0,1)) * rollForce);
    // }
}