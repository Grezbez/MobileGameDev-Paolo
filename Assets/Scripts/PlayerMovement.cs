using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
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

            Debug.Log(touchPosition);

            // Convert the touch position from screen space to world space
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            Debug.Log(worldPosition);
        }
    }
}
