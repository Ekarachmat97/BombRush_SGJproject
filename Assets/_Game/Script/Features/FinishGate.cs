using UnityEngine;

public class FinishGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeBomb timeBomb = FindFirstObjectByType<TimeBomb>();
            if (timeBomb != null)
            {
                timeBomb.Explode();
            }
            else
            {
                Debug.LogWarning("No TimeBomb found to explode!");
            }
            Destroy(gameObject);
        }
    }
}