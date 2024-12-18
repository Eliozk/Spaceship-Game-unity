using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    [SerializeField][Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;
    //[SerializeField] NumberField scoreField;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            other.transform.position = Vector3.zero;

            // מציאת קומפוננטת PlayerHealth של החללית
            PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

            // אם החיים הנוכחיים > 0, לא נסיים את המשחק
            if (playerHealth != null && playerHealth.currentLives > 0)
            {
                Debug.Log("Elioz: Player still has lives left. Not ending the game.");
                return; // לא עובר לסצנה אחרת
            }

            // אם אין חיים - מעבר לסצנה הבאה
            Debug.Log("Elioz: No lives left. Game Over.");
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
