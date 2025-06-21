using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float rotationSpeed = 10f;

    private Transform cameraTransform; 

    private CharacterController controller;
    private Vector3 velocity;
    private float _turnSmoothVelocity;
    private ParticleSystem dustCloud;
    private Animator animator;

    private void Start()
    {
        dustCloud = GetComponentInChildren<ParticleSystem>();
        //animator get children
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        GameObject camObj = GameObject.FindGameObjectWithTag("MainCamera");
        if (camObj != null)
            cameraTransform = camObj.transform;
        else
            Debug.LogWarning("MainCamera not found! Please tag your camera as 'MainCamera'.");
    }

    private void Update()
    {
        MoveAndRotate();
        HandleJumpAndGravity();
    }

    private void MoveAndRotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 moveDir = Vector3.zero;
        bool isMoving = false;
        if (inputDir.magnitude >= 0.1f && cameraTransform != null)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            isMoving = true;
        }

        if (animator != null)
        animator.SetBool("isMoving", isMoving);

        if (dustCloud != null)
        {
            if (isMoving && controller.isGrounded)
            {
                if (!dustCloud.isPlaying)
                    dustCloud.Play();
            }
            else
            {
                if (dustCloud.isPlaying)
                    dustCloud.Stop();
            }
        }

        Vector3 move = moveDir.normalized * moveSpeed;
        move.y = velocity.y;
        controller.Move(move * Time.deltaTime);
    }

    private void HandleJumpAndGravity()
    {
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                
                if (animator != null)
                animator.SetTrigger("isJumping");
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }
}