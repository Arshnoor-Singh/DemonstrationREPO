using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    public float movementSpeed = 0.1f;

    public float gravity = 9.8f;
    public float jumpSpeed = 5;
    public float verticalSpeed = 0;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if(context.started == true && GroundCheck())
        {
            verticalSpeed = jumpSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GroundCheck() == true && verticalSpeed <= 0)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed = verticalSpeed - gravity * Time.deltaTime;
        }

        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, movementInput.y * movementSpeed * Time.deltaTime);
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1.1f);
    }
}
