using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 300.0f;
    [SerializeField] float zoomSpeed = 600.0f;
    [SerializeField] float zoomAmount = 0.0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // rotate camera based on mouse actions
            // TODO: refactor
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * -rotateSpeed, 0);
        }
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            // move camera forward / backward
            zoomAmount = Mathf.Clamp(zoomAmount + Input.GetAxis("Mouse Y") * Time.deltaTime * -zoomSpeed, -5.0f, 5.0f);
            Camera.main.transform.localPosition = new Vector3(0, 0, zoomAmount);
        }
    }
}
