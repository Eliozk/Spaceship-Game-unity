using System.Collections;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    [Tooltip("Prefab of the Shield Item")]
    [SerializeField] GameObject shieldItemPrefab; // Prefab של השיקוי

    [Tooltip("Time interval between spawns in seconds")]
    [SerializeField] float spawnInterval; // מרווח בין הופעות

    [Tooltip("Size of the spawn area (width x height)")]
    [SerializeField] Vector2 spawnAreaSize = new Vector2(10f, 5f); // שטח ההופעה

    [Tooltip("Duration for which the shield item stays active")]
    [SerializeField] float shieldDuration; // משך זמן הופעת השיקוי

    [Tooltip("Delay before the first spawn")]
    [SerializeField] float initialSpawnDelay; // עיכוב לפני הופעת השיקוי הראשון

    private GameObject currentShieldInstance; // שמירה על השיקוי שנוצר כרגע

    private void Start()
    {
        // להתחיל את מנגנון הופעת השיקויים עם עיכוב התחלתי
        StartCoroutine(SpawnShieldItem());
    }

    private IEnumerator SpawnShieldItem()
    {
        // המתנה לפני הופעת השיקוי הראשון
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true) // לולאה אינסופית
        {
            // יצירת שיקוי חדש במיקום אקראי
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                0f
            );

            currentShieldInstance = Instantiate(shieldItemPrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Shield spawned at position: {spawnPosition}");

            // מחיקת השיקוי אם הוא נשאר על המסך יותר מדי זמן
            yield return new WaitForSeconds(shieldDuration);
            if (currentShieldInstance != null) // בדיקה שהשיקוי עדיין קיים
            {
                Destroy(currentShieldInstance);
                Debug.Log("Shield removed after duration expired.");
            }

            // המתנה עד לסבב הבא
            yield return new WaitForSeconds(spawnInterval - shieldDuration);
        }
    }

    public void RemoveShieldIfCollected()
    {
        if (currentShieldInstance != null)
        {
            Destroy(currentShieldInstance);
            Debug.Log("Shield collected and removed.");
        }
    }

    private void OnDrawGizmos()
    {
        // מצייר את שטח ההופעה בסצנה (בזמן עריכה)
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 1));
    }
}
