using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;

    [Header("Player Settings")]
    [SerializeField] private float movementSpeed = 1f;
    

    private float cameraRotY;

    void Start()
    {

    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(inputX, 0, inputZ);
        movement = transform.InverseTransformDirection(movement);

        _characterController.Move(movement * movementSpeed * Time.deltaTime);
    }
}
