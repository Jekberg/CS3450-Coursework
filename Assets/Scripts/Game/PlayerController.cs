using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private static GameObject player;
    public float dashForce = 100.0f;
    public float movementSpeed = 100.0f;
    public float mouseSensitivity = 100.0f;

    [SerializeField] private float dashRechargeDurarion = 10.0f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform playerBody;

    private Vector3 velocity; // For maintaining the acceleration for jumping

    private PlayerController() { }

    public float DashCharge
    {
        get;
        private set;
    }

    public Health Health
    {
        get { return GetComponent<Health>();  }
    }

    private bool Jump { get { return Input.GetButtonDown("Jump"); } }
    private float MouseX { get { return Input.GetAxis("Mouse X") * Time.deltaTime; } }
    private float MouseY { get { return Input.GetAxis("Mouse Y") * Time.deltaTime; } }
    private float MoveX { get { return Input.GetAxis("Horizontal") * Time.deltaTime; } }
    private float MoveZ { get { return Input.GetAxis("Vertical") * Time.deltaTime; } }

    private CharacterController Controller {
        get {
            return GetComponent<CharacterController>();
        }
    }

    public static PlayerController Player
    {
        get { return player.GetComponent<PlayerController>(); }
    }

    public void Push(float force, Transform location)
    {
        var pushDirection = (transform.position - location.position).normalized;
        velocity += force * Vector3.Scale(pushDirection, Vector3.right + Vector3.forward);
    }

    private void Awake()
    {
        player = gameObject;
        Health.onHealthUpdate += HandleHealthUpdate;
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

	private void Update()
    {
        CameraRotation();
        PlayerMovement();
        DashMovement();
    }

    private void CameraRotation()
    {
        var rotation = playerCamera.transform.rotation.eulerAngles;
        rotation.x -= MouseY * mouseSensitivity;
        
        // Clamp the camera between -X and X
        const float MaxXAngle = 50;
        if (MaxXAngle < rotation.x && rotation.x < 360 - MaxXAngle)
            rotation.x = rotation.x > 180 ? -MaxXAngle : MaxXAngle;
        playerCamera.transform.rotation = Quaternion.Euler(rotation);
        playerBody.Rotate(Vector3.up * MouseX * mouseSensitivity);
    }

    private void PlayerMovement()
    {
        const float HorizontalVelocityEase = 0.33f; // 0 = no velocity
        
        Controller.Move(movementSpeed * (playerBody.right * MoveX + playerBody.forward * MoveZ));   
        velocity += Physics.gravity * Time.deltaTime;
        velocity.x *= Mathf.Pow(HorizontalVelocityEase, Time.deltaTime);
        velocity.z *= Mathf.Pow(HorizontalVelocityEase, Time.deltaTime);
        var collision = Controller.Move(velocity * Time.deltaTime);
        if (CollisionFlags.Below == collision)
        {
            velocity.y = 0;
            if (Jump)
                velocity.y = Mathf.Sqrt(-2 * jumpHeight * Physics.gravity.y);
        }

    }

    private void DashMovement()
    {
        // Recharge the 
        if (1.0f < DashCharge)
            DashCharge = 1.0f;
        else
            DashCharge += Time.deltaTime / dashRechargeDurarion;
        if (Input.GetMouseButtonDown(1))
        {
            // Diminishing returns if the charge is not ready.
            velocity += dashForce * DashCharge * DashCharge * transform.forward;
            DashCharge = 0.0f;
        }
    }

    private void HandleHealthUpdate(float health)
    {
        if (health <= 0.0f)
        {
            Debug.Log("The player is dead");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // Nothing here is too excited excpet for enemy collisions
        var enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Push(enemy.PushForce, enemy.transform);
            Debug.Log(string.Format("Player collision: {0}", collision));
            Health.Damage(enemy.DamageAmount);
        }
        
        var healthPack = collision.gameObject.GetComponent<HealthPack>();
        if (healthPack != null)
            healthPack.UseOn(Health);
    }
}
