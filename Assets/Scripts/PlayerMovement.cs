using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forcePower;
    [SerializeField] private float maxVelocity;

    private Camera mainCamera;
    private Rigidbody rb;

    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Assign the main camera to the 'mainCamera' variable
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the primary touch is pressed on the touchscreen
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Get the position of the touch input
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

           /// Debug.Log(touchPosition);

            // Convert the touch position from screen space to world space
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

           /// Debug.Log(worldPosition);
           
            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void FixedUpdate() //Fixed update because it is called every time the physics system updates and it is more consistent
    {
        if (movementDirection == Vector3.zero) {return; }

        rb.AddForce(movementDirection * forcePower * Time.deltaTime, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
