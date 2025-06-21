using UnityEngine;

public class ActivatedButton : MonoBehaviour
{
    [SerializeField] private GameObject gateObject;
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (gateObject != null)
        {
            Destroy(gateObject);
        }
    }
}