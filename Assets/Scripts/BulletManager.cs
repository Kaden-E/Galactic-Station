using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != null){}
            Destroy(this.gameObject);
        Debug.Log(collision.gameObject);
    }
}
