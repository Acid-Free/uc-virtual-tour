using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 300.0f;
    [SerializeField] float zoomSpeed = 600.0f;
    float fieldOfView = 60.0f;

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
            // move camera forward/backward
            fieldOfView = Mathf.Clamp(fieldOfView + Input.GetAxis("Mouse Y") * Time.deltaTime * -zoomSpeed, 40.0f, 80.0f);
            Camera.main.fieldOfView = fieldOfView;
        }
    }
}
