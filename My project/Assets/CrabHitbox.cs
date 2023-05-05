using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabHitbox : MonoBehaviour
{

    HitboxManager hitboxManager;

    // Start is called before the first frame update
    void Start()
    {
        hitboxManager = this.transform.root.GetComponent<HitboxManager>();
    }

    void OnTriggerEnter(Collider collision) {
        StartCoroutine(hitboxManager.gotHit());
    }

}
