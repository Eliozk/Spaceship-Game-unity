using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float durationShieldActive;

    [Tooltip("Prefab of the shield pickup")]
    [SerializeField] GameObject shieldPickupPrefab;

    [Tooltip("Spawn area size (width x height)")]
    [SerializeField] Vector2 spawnAreaSize;

    private bool isShieldActive = false; // משתנה למניעת הפעלה כפולה של המגן
    public GameObject Shield;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isShieldActive)
        {
            Debug.Log("Shield triggered by player");

            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();

            if (destroyComponent != null)
            {
                isShieldActive = true; // למנוע הפעלה נוספת
                ShieldTemporarily(destroyComponent); // הפעלת מגן זמני
                Destroy(this.gameObject); // מחיקת השיקוי
            }
        }
    }

    private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent)
    {
        destroyComponent.enabled = false; // ביטול אפשרות פגיעה בשחקן
        Debug.Log("Shield activated!");

        await Task.Delay((int)(durationShieldActive * 1000)); // המתנה למשך זמן המגן

        destroyComponent.enabled = true; // החזרת אפשרות הפגיעה בשחקן
        Debug.Log("Shield deactivated.");
    }

    // פונקציה לדוגמה ליצירת שיקויים במיקום אקראי (אם צריך)
    public void SpawnShield()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2), 0f);
        Instantiate(shieldPickupPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Shield spawned at position: {spawnPosition}");
    }
}
