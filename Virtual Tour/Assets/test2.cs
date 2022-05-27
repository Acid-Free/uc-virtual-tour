using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public Transform basis;

    Vector3 previousPos;
    Vector3 currentPos;
    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        previousPos = currentPos;
        currentPos = basis.transform.position;
        vel = currentPos - previousPos;
        if (vel.magnitude > 0)

        transform.position = basis.position + vel.normalized * vel.magnitude * 2;
    }
}
