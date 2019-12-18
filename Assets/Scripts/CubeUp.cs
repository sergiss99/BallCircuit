﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUp : MonoBehaviour
{
    public float impulseForce = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
