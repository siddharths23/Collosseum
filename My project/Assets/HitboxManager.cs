using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HitboxManager : NetworkBehaviour
{
    public Collider[] hitboxs;
    
    public IEnumerator gotHit()
    {
        disableHitboxs();
        yield return new WaitForSeconds(1);
        enableHitboxs();
        // return;
    }

    void disableHitboxs()
    {
        foreach (Collider hitbox in hitboxs)
        {
            hitbox.enabled = false;
        }
    }

    void enableHitboxs()
    {
        foreach (Collider hitbox in hitboxs)
        {
            hitbox.enabled = true;
        }
    }
    
}
