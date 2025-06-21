using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 100f;

    private float yaw = 0f;
    private float pitch = 0f;

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
        Cursor.lockState = CursorLockMode.Locked; // Kunci kursor di tengah layar
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f); // Batasi sudut vertikal

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target.position);
    }
}
