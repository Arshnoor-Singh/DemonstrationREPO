using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    public float movementSpeed = 0.1f;

    bool jumpExecuted;
    public float gravity = 9.8f;
    public float jumpSpeed = 20;
    public float verticalSpeed = 0;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            jumpExecuted = true;
            Debug.Log("IA Debug Jump = " + jumpExecuted);
        }
        else
        {
            jumpExecuted = false;
            Debug.Log("IA Debug Jump = " + jumpExecuted);
        }
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed = (verticalSpeed - gravity) * Time.deltaTime;

        if (GroundCheck() == true && jumpExecuted == false)
        {
            Debug.Log("Jump Condition Failed");
            verticalSpeed = 0;
        }

        if(GroundCheck() == true && jumpExecuted == true)
        {
            Debug.Log("Jump Condition Successful");
            verticalSpeed = jumpSpeed;
        }

        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalSpeed, movementInput.y * movementSpeed * Time.deltaTime);
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1);
    }
}
