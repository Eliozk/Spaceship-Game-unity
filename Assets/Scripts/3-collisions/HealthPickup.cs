using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    [Tooltip("The amount of health to restore")]
     [SerializeField] int healthToRestore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // בדיקת התנגשות עם השחקן
        if (other.CompareTag("Player"))
        {
            Debug.Log("1 Health pickup collected by player!");

            // מציאת קומפוננטת הבריאות של השחקן והוספת לב
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && playerHealth.currentLives < playerHealth.maxLives)
            {
                playerHealth.AddHealth(healthToRestore); // להוסיף פונקציה חדשה
            }

            // השמדת נקודת הבריאות אחרי שנאספה
            Destroy(gameObject);
        }
    }
}
