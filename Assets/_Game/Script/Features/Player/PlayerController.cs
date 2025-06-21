using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SquadAI[] squadAIs;
    private bool isFollowing = false;
    [SerializeField] GameObject timeBombPrefab;
    [SerializeField] Transform timeBombSpawnPoint;

    void Start()
    {
        squadAIs = Object.FindObjectsByType<SquadAI>(FindObjectsSortMode.None);
        if (squadAIs == null || squadAIs.Length == 0)
            Debug.LogWarning("No SquadAI found in the scene!");


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFollow();
        }

        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     SpawnTimeBomb();
        // }
    }

    private void ToggleFollow()
    {
        if (squadAIs == null) return;

        if (isFollowing)
        {
            foreach (var squad in squadAIs)
            {
                if (squad != null)
                    squad.Follow();
            }
        }
        else
        {
            foreach (var squad in squadAIs)
            {
                if (squad != null)
                    squad.UnFollow();
            }
        }

        isFollowing = !isFollowing;
    }

    public void SpawnTimeBomb()
    {

        if (timeBombPrefab != null && timeBombSpawnPoint != null)
        {
            GameObject timeBomb = Instantiate(timeBombPrefab, timeBombSpawnPoint.position, timeBombSpawnPoint.rotation);
            timeBomb.transform.SetParent(timeBombSpawnPoint, worldPositionStays: true);
            timeBomb.transform.localScale = timeBombPrefab.transform.localScale;
        
        }
        else
        {
            Debug.LogError("TimeBomb prefab or spawn point is not set. Please assign them in the inspector.");
        }
    }
}
