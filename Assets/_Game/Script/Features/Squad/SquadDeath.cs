using UnityEngine;

public class SquadDeath : MonoBehaviour
{
    [Header("Squad Settings")]
    public GameObject fractionSquadPrefab;
    public int amountFractionn = 8;
    public float fractionForce = 5f;
    public float practionLifetime = 1.5f;

    public void OnSquadExplode()
    {
        // Spawn pecahan tubuh
        for (int i = 0; i < amountFractionn; i++)
        {
            GameObject fraction = Instantiate(fractionSquadPrefab, transform.position, Random.rotation);
            Rigidbody rb = fraction.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDir = Random.onUnitSphere;
                rb.AddForce(randomDir * fractionForce, ForceMode.Impulse);
            }
            Destroy(fraction, practionLifetime);
        }
        Destroy(gameObject);
    }
}
