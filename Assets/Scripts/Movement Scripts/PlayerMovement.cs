using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    public float movementSpeed = 0.1f;
    public Cinemachine.CinemachineFreeLook playerCamera;
    public float rayLength = 5f;

    public float gravity = 9.8f;
    public float jumpSpeed = 5;
    public float verticalSpeed = 0;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if(context.started == true && GroundCheck() == true)
        {
            verticalSpeed = jumpSpeed;
        }
    }

    public void IAInteract(InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            InteractionRayCast();
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

    public void InteractionRayCast()
    {
        // Storing the value of the direction in which the camera is looking in a variable named CameraDirection
        // The type of this variable is Vector3
        Vector3 CameraDirection = Camera.main.transform.forward;

        // Storing the information about where our ray starts, and in which direction it needs to go, inside a variable called Interaction Ray
        // The type of this variable is Ray
        Ray InteractionRay = new Ray(playerCamera.transform.position, CameraDirection);

        // Storing the information about whatever my raycast hits in a variable called targetInfo
        // The type of this variable is RaycastHit
        RaycastHit targetInfo;

        // Firing the ray using the information collected above
        // The keyword out sends the data of whatever game object that has been hit by the raycast, into the variable name specified after the word out
        // Obviously, the type of this variable needs to be RaycastHit
        if(Physics.Raycast(InteractionRay, out targetInfo, rayLength) == true)
        {
            // Drawing a debug line to be able to see the ray for testing purposes
            // This line is drawn if we hit something
            Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (CameraDirection * rayLength), Color.red, 2f);

            // Checking if the target info variable (which store the information about the object that was hit by the raycast) has a interaction component
            if(targetInfo.transform.gameObject.GetComponent<InteractionComponent>() == true)
            {
                // Since the hit object contains the Interaction component, Execute the Intercation component function
                targetInfo.transform.gameObject.GetComponent<InteractionComponent>().InteractionExecuted();
            }
            else
            {
                // If the hit object does not contain an interaction component, Simply print the following debug log
                Debug.Log("Hit object does not conatain an interaction component");
            }
        }
        else
        {
            // Drawing a debug line to be able to see the ray for testing purposes
            // This line is drawn if we do not hit something
            Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (CameraDirection * rayLength), Color.magenta, 2f);
        }
    }

    public void Function1()
    {

    }

    public void Function2(bool isTrue)
    {
        
    }

    public void Function3()
    {

    }
    
}
