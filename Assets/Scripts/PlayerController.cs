using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100.0f;
    public float mouseSensitivity = 100.0f;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Transform playerBody;

    [SerializeField]
    private CharacterController controller;

    private float MouseX { get { return Input.GetAxis("Mouse X") * Time.deltaTime; } }
    private float MouseY { get { return Input.GetAxis("Mouse Y") * Time.deltaTime; } }
    private float MoveX { get { return Input.GetAxis("Horizontal") * Time.deltaTime; } }
    private float MoveZ { get { return Input.GetAxis("Vertical") * Time.deltaTime; } }


    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(playerCamera ==  null)
            playerCamera = Camera.main;
    }

	public void Update()
    {
        CameraRotation();
        PlayerMovement();
        f();
    }

    private void CameraRotation()
    {
        var rotation = playerCamera.transform.rotation.eulerAngles
            - Vector3.right * MouseY * mouseSensitivity;
        
        // Clamp the camera between -X and X
        const float MaxXAngle = 45;
        if (MaxXAngle < rotation.x && rotation.x < 360 - MaxXAngle)
            rotation.x = rotation.x > 180 ? -MaxXAngle : MaxXAngle;
        playerCamera.transform.rotation = Quaternion.Euler(rotation);
        playerBody.Rotate(Vector3.up * MouseX * mouseSensitivity);
    }

    private void PlayerMovement()
    {
        controller.Move(movementSpeed * (
            playerBody.right * MoveX + playerBody.forward * MoveZ));
    }

    private void f()
    {
        controller.Move(-Vector3.up);
    }
}
