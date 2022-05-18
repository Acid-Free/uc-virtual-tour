using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 300.0f;
    [SerializeField] float zoomSpeed = 600.0f;
    [SerializeField] float minFieldOfView = 40.0f;
    [SerializeField] float maxFieldOfView = 110.0f;
    [SerializeField] float defaultFieldOfView = 60.0f;
    float fieldOfView = 60.0f;

    void Start()
    {
        fieldOfView = defaultFieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // rotate camera based on mouse actions
            // TODO: refactor
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed, transform.eulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * -rotateSpeed, 0);
        }
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            // move camera forward/backward
            fieldOfView = Mathf.Clamp(fieldOfView + Input.GetAxis("Mouse Y") * Time.deltaTime * zoomSpeed, minFieldOfView, maxFieldOfView);
            Camera.main.fieldOfView = fieldOfView;
        }
    }

    public void ResetCamera()
    {
        transform.rotation = Quaternion.identity;
        fieldOfView = 60.0f;
    }

    public void ResetCamera(Vector3 lookRotation, float fieldOfView)
    {
        transform.eulerAngles = lookRotation;
        // TODO: refactor
        this.fieldOfView = fieldOfView;
        Camera.main.fieldOfView = fieldOfView;
    }
}
