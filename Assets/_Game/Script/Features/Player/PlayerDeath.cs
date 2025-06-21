using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject playerBody;
    public GameObject pecahanPlayerPrefab;
    public int jumlahPecahan = 8;
    public float pecahanForce = 5f;
    public float pecahanLifetime = 1.5f;
    public float respawnDelay = 2f;

    [SerializeField] private GameObject deathUI;
    private PlayerController playerController;

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    private void Start()
    {

    }

    public void OnPlayerExplode()
    {
        StartCoroutine(RespawnRoutine());
        
    }

    private IEnumerator RespawnRoutine()
    {
        // Hancurkan player body
        if (playerBody != null)
            playerBody.SetActive(false);

        // Spawn pecahan tubuh
        for (int i = 0; i < jumlahPecahan; i++)
        {
            GameObject pecahan = Instantiate(pecahanPlayerPrefab, transform.position, Random.rotation);
            Rigidbody rb = pecahan.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDir = Random.onUnitSphere;
                rb.AddForce(randomDir * pecahanForce, ForceMode.Impulse);
            }
            Destroy(pecahan, pecahanLifetime);
        }

        yield return new WaitForSeconds(respawnDelay);
        // deathUI.SetActive(true);
        GameManager.Instance.RestartGame();
    }




    public void ContinueGame()
    {
        // Resume the game
        GameManager.Instance.ResumeGame();
    }

    public void ExitGame()
    {
        // Go to main menu
        GameManager.Instance.GoToMainMenu();
        GameManager.Instance.ResumeGame();
    }
}