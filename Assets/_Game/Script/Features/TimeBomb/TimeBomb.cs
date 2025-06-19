using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    [Header("Bomb Settings")]
    public float countdown = 5f;
    public GameObject pecahanBombPrefab;
    public int jumlahPecahan = 10;
    public float force = 5f;
    public float pecahanLifetime = 1f; 

    private float timer;

    private bool hasExploded = false;
    private PlayerDeath playerDeath;

    private void Start()
    {
        timer = countdown;
        playerDeath = FindFirstObjectByType<PlayerDeath>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (!hasExploded && timer <= 0f)
        {
            Explode();
        }
    }

    public void Explode()
    {
        hasExploded = true;

        for (int i = 0; i < jumlahPecahan; i++)
        {
            GameObject pecahan = Instantiate(pecahanBombPrefab, transform.position, Random.rotation);

            Rigidbody rb = pecahan.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDir = Random.onUnitSphere; 
                rb.AddForce(randomDir * force, ForceMode.Impulse);
            }
            Destroy(pecahan, pecahanLifetime); 
        }
        //playerdeath
       
        if (playerDeath != null)
        {
            playerDeath.OnPlayerExplode();
        }

        Destroy(gameObject); 
    }
}
