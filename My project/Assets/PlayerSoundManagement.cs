using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManagement : MonoBehaviour
{
   public void PlaySound(string path)
   {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
   }
}
