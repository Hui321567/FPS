using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }

   
}
