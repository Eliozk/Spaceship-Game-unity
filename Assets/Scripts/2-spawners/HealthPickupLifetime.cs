using System.Collections;
using UnityEngine;

public class HealthPickupLifetime : MonoBehaviour
{
    [Tooltip("משך הזמן שהשיקוי יופיע על המסך (בשניות)")]
    [SerializeField] private float lifetime = 4f;

    private void Start()
    {
        // השמדת האובייקט לאחר הזמן שהוגדר
        Destroy(gameObject, lifetime);
    }
}
