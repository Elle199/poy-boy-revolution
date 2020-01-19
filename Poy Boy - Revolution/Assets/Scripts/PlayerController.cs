using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform grndCheckTrans;

    [Header("Player Settings")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float gravity = -9.82f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;

    private Vector3 velocity = Vector3.zero;
    private bool isGrounded;

    void Start()
    {

    }

    void Update()
    {
        Vector3 grndCheckEnd = grndCheckTrans.position;
        grndCheckEnd.y += groundDistance;
        isGrounded = Physics.CheckCapsule(grndCheckTrans.position, grndCheckEnd, 1, groundMask);
        
        float inputX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        float inputZ = Input.GetAxisRaw("Vertical") * movementSpeed;

        Vector3 movement = new Vector3(inputX, 0, inputZ);
        movement = transform.TransformDirection(movement);

        velocity.y += gravity * Time.deltaTime;

        if (isGrounded)
        {
            velocity.y = gravity;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        movement.y = velocity.y;

        _characterController.Move(movement * Time.deltaTime);
    }
}
