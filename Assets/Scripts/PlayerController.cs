using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MouseSensitivity = 100.0f;
    public Transform playerBody;
    public CharacterController controller;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	public void Update()
    {
        var rotation = playerBody.localRotation.eulerAngles
            - Vector3.right * Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime
            + Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;

        // Clamp the camera between -X and X
        const float MaxXAngle = 45;
        if (MaxXAngle < rotation.x && rotation.x < 360 - MaxXAngle)
            rotation.x = rotation.x > 180 ? -MaxXAngle : MaxXAngle;
        playerBody.localRotation = Quaternion.Euler(rotation);
	}
}
