/// <summary>code write seccastudio</summary>
/// 
/// 
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(CharacterController))]
public class SquadAI : MonoBehaviour
{
    [Header("Follow Settings")]
    public string playerTag = "Player";
    public float followDistance = 2.5f;

    [Header("Obstacle Jumping")]
    public float obstacleDetectDistance = 1.5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public LayerMask obstacleMask;

    private Transform playerTransform;
    private NavMeshAgent agent;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool hasJumped = false;

    public bool isFollowing = true;
    private Animator animator;
    private ParticleSystem dustCloud;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        dustCloud = GetComponentInChildren<ParticleSystem>();

        // Sync posisi via CharacterController
        agent.updatePosition = false;
        agent.updateRotation = true;

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            playerTransform = playerObj.transform;
        else
            Debug.LogWarning("Player with tag '" + playerTag + "' not found!");
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            hasJumped = false;
        }
        bool isMoving = false;

        if (isFollowing && playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > followDistance)
            {
                Vector3 dir = (transform.position - playerTransform.position).normalized;
                Vector3 targetPos = playerTransform.position + dir * followDistance;

                if (!hasJumped && isGrounded && DetectObstacleAhead())
                {
                    Jump();
                    hasJumped = true;

                    if (animator != null)
                    animator.SetTrigger("isJumping");
                }
                else
                {
                    agent.SetDestination(targetPos);
                }
            }
            else
            {
                agent.ResetPath();
            }
        }

        // Gerakkan squad berdasarkan pathfinding
        if (agent.hasPath)
        {
            Vector3 move = agent.desiredVelocity;
            controller.Move(move * Time.deltaTime);

            if (move.magnitude > 0.1f)
            isMoving = true;
        }

        if (animator != null)
        animator.SetBool("isMoving", isMoving);

        if (dustCloud != null)
        {
            if (isMoving && isGrounded)
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

        // Tambahkan gravitasi
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Sinkronkan posisi agent
        agent.nextPosition = transform.position;
    }


    bool DetectObstacleAhead()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        Vector3 direction = transform.forward;

        return Physics.Raycast(origin, direction, obstacleDetectDistance, obstacleMask);
    }

    void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    public void Follow()
    {
        isFollowing = true;
    }

    public void UnFollow()
    {
        isFollowing = false;
        if (agent != null)
            agent.ResetPath();
    }
}
