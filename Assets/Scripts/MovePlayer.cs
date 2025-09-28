using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private Vector3 positionOrigin;
    [SerializeField]
    private Vector3 rotationOrigin;
    public float speed;
    public float rotationSpeed = 360;
    public VariableJoystick variableJoystick;
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        positionOrigin = transform.position;
        rotationOrigin = transform.eulerAngles;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = rotationOrigin;
        transform.position = positionOrigin;
    }

    public void Update()
    {
        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);

        if (inputDirection.magnitude > 0.1f)
        {
            // Get the camera's forward and right directions (flattened to the XZ plane)
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Move relative to camera orientation
            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;

            // Move the player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotate the player toward the move direction
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            animator.SetFloat("moveSpeed", inputDirection.magnitude);
        }
        else
        {
            animator.SetFloat("moveSpeed", 0f);
        }
    }
}
