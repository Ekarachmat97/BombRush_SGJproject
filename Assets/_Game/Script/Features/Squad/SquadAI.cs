using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class SquadAI : MonoBehaviour
{
    [Header("Follow Settings")]
    public string playerTag = "Player";
    public float followDistance = 2.5f;

    private Transform playerTransform;
    private NavMeshAgent agent;
    public bool isFollowing = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            playerTransform = playerObj.transform;
        else
            Debug.LogWarning("Player with tag '" + playerTag + "' not found!");
    }

    void Update()
    {
        if (isFollowing && playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > followDistance)
            {
                Vector3 dir = (transform.position - playerTransform.position).normalized;
                Vector3 targetPos = playerTransform.position + dir * followDistance;
                agent.SetDestination(targetPos);
            }
            else
            {
                agent.ResetPath();
            }
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