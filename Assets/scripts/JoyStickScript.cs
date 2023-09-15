using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoyStickScript : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 7.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = 0f; // Adjusted gravity value
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        
    }

    void Update()
    {

        MovementOfPlayer();
    }

    public void MovementOfPlayer()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, input.y, 0);
        move.Normalize(); // Normalize to ensure consistent speed in all directions
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // resticts player movement 
        if (transform.position.x > 9)
        {
            this.transform.position = new Vector3(9, transform.position.y, 0);

        }
        else if (transform.position.x < -9)
        {

            this.transform.position = new Vector3(-9, transform.position.y, 0);

        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 5.6f), 0);
    }
}
