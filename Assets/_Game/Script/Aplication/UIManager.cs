using UnityEngine;

/// <summary>
/// Mengurus tampilan UI atau game object secara terpusat
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Mengaktifkan sebuah game object
    /// </summary>
    public void EnableTarget(GameObject target)
    {
        if (target != null && !target.activeSelf)
        {
            target.SetActive(true);
        }
    }

    /// <summary>
    /// Menonaktifkan sebuah game object
    /// </summary>
    public void DisableTarget(GameObject target)
    {
        if (target != null && target.activeSelf)
        {
            target.SetActive(false);
        }
    }

}
