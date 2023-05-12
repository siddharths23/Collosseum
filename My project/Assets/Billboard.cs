using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    
    public Transform cam;

    void Start()
    {
        int i;
        for(i = 0; i < 10 ; i++) {
            if (this.transform.root.GetChild(i).name == "CameraHolder"){
                break;
            }
        }
        cam = this.transform.root.GetChild(i);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
