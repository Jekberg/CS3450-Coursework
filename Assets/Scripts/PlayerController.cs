using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100.0f;
    public float mouseSensitivity = 100.0f;

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Transform playerBody;

    [SerializeField]
    private CharacterController controller;

    private Vector3 velocity;

    private bool Jump { get { return Input.GetButtonDown("Jump"); } }
    private float MouseX { get { return Input.GetAxis("Mouse X") * Time.deltaTime; } }
    private float MouseY { get { return Input.GetAxis("Mouse Y") * Time.deltaTime; } }
    private float MoveX { get { return Input.GetAxis("Horizontal") * Time.deltaTime; } }
    private float MoveZ { get { return Input.GetAxis("Vertical") * Time.deltaTime; } }


    public void Start()
    {
        if(playerCamera ==  null)
            playerCamera = Camera.main;
    }

	public void Update()
    {
        CameraRotation();
        PlayerMovement();
    }

    private void CameraRotation()
    {
        var rotation = playerCamera.transform.rotation.eulerAngles;
        rotation.x -= MouseY * mouseSensitivity;
        
        // Clamp the camera between -X and X
        const float MaxXAngle = 45;
        if (MaxXAngle < rotation.x && rotation.x < 360 - MaxXAngle)
            rotation.x = rotation.x > 180 ? -MaxXAngle : MaxXAngle;
        playerCamera.transform.rotation = Quaternion.Euler(rotation);
        playerBody.Rotate(Vector3.up * MouseX * mouseSensitivity);
    }

    private void PlayerMovement()
    {
        controller.Move(movementSpeed * (playerBody.right * MoveX + playerBody.forward * MoveZ));
        velocity += Physics.gravity * Time.deltaTime;
        var collision = controller.Move(velocity * Time.deltaTime);
        if (CollisionFlags.Below == collision)
        {
            velocity.y = 0;
            if (Jump)
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
        }
    }
}
