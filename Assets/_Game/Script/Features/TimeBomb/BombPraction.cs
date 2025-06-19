using System.Collections;
using UnityEngine;

public class BombPraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Squad"))
        {
            SquadDeath squadDeath = FindFirstObjectByType<SquadDeath>();
            if (squadDeath != null)
            {
                squadDeath.OnSquadExplode();
            }

            StartCoroutine(OnGameOver());
        }
    }

    IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.GameOver();
    }
}