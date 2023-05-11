using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class CameraController : NetworkBehaviour
{
    public GameObject CameraHolder;
    public Vector3 offset;

    public override void OnStartAuthority()
    {
        CameraHolder.SetActive(true);
    }

    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "SethScene")
        {
         
            CameraHolder.transform.rotation = transform.rotation;

           
            CameraHolder.transform.position = transform.position + transform.rotation * offset;
        }
    }
}
