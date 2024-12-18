using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles transitioning to the next level or scene when a specific tag triggers the collider.
/// </summary>
public class GotoNextLevel : MonoBehaviour
{
    /// <summary>
    /// The tag that triggers the transition to the next level.
    /// </summary>
    [SerializeField] private string triggeringTag;

    /// <summary>
    /// The name of the scene to move to when the given tag triggers the collider.
    /// </summary>
    [SerializeField, Tooltip("Name of scene to move to when triggering the given tag")] private string sceneName;

    /// <summary>
    /// Handles the collision event for transitioning to the next scene.
    /// </summary>
    /// <param name="other">The collider of the object that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            // Reset the object's position to the origin.
            other.transform.position = Vector3.zero;

            // Find the PlayerHealth component attached to the player.
            PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

            // Check if the player still has lives left.
            if (playerHealth != null && playerHealth.currentLives > 0)
            {
                Debug.Log("Player still has lives left. Not ending the game.");
                return; // Do not transition to another scene.
            }

            // If no lives are left, transition to the next scene.
            Debug.Log("No lives left. Game Over.");
            SceneManager.LoadScene(sceneName); // Load the specified scene by name.
        }
    }
}
