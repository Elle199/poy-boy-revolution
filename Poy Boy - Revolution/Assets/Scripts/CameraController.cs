using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [Header("Camera Settings")]
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float minCameraClamp = -10;
    [SerializeField] private float maxCameraClamp = 10;

    private Vector3 offset = Vector3.zero;

    private float rotX;
    private float rotY;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {


        rotX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, minCameraClamp, maxCameraClamp);
    }
}
