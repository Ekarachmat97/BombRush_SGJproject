using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    [SerializeField] private float smoothSpeed = 5f;

    private void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag("Player");
        if (targetObj != null)
        {
            target = targetObj.transform;
            offset = transform.position - target.position;
        }
        else
        {
            Debug.LogWarning("CameraFollow: Target dengan tag 'Player' tidak ditemukan!");
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
