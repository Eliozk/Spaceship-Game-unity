using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [Tooltip("The prefab of the health pickup")]
    [SerializeField] GameObject healthPickupPrefab; // Prefab של נקודת הבריאות

    [Tooltip("Time in seconds between spawns")]
    [SerializeField] float spawnInterval = 5f; // זמן בין הופעה להופעה
    
    [Tooltip("The area where health pickups can spawn")]
    [SerializeField] Vector2 spawnAreaSize = new Vector2(17, 8);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnHealthPickup), spawnInterval, spawnInterval);
    }

    private void SpawnHealthPickup()
    {
        // יצירת מיקום רנדומלי בתוך האזור
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        // ספאון של נקודת הבריאות
        Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Health pickup spawned at: " + spawnPosition);
    }

    private void OnDrawGizmosSelected()
    {
        // ציור אזור הספאון להמחשה
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
