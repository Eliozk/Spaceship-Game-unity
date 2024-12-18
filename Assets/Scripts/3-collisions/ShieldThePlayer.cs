using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This class handles the functionality of a temporary shield for the player.
/// It disables the player's vulnerability for a set duration when the shield is picked up.
/// </summary>
public class ShieldThePlayer : MonoBehaviour
{
    /// <summary>
    /// The number of seconds the shield remains active.
    /// </summary>
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] private float durationShieldActive;

    /// <summary>
    /// Prefab of the shield pickup that will spawn in the game.
    /// </summary>
    [Tooltip("Prefab of the shield pickup")]
    [SerializeField] private GameObject shieldPickupPrefab;

    /// <summary>
    /// Defines the size of the area where the shield can spawn.
    /// </summary>
    [Tooltip("Spawn area size (width x height)")]
    [SerializeField] private Vector2 spawnAreaSize;

    /// <summary>
    /// Flag to prevent multiple activations of the shield.
    /// </summary>
    private bool isShieldActive = false;

    /// <summary>
    /// Reference to the shield game object.
    /// </summary>
    public GameObject Shield;

    /// <summary>
    /// Trigger event for activating the shield when the player collides with it.
    /// </summary>
    /// <param name="other">The collider of the object that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isShieldActive)
        {
            Debug.Log("Shield triggered by player");

            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();

            if (destroyComponent != null)
            {
                isShieldActive = true; // Prevents repeated activation
                ShieldTemporarily(destroyComponent); // Activates the temporary shield
                Destroy(this.gameObject); // Deletes the shield pickup object
            }
        }
    }

    /// <summary>
    /// Temporarily disables the player's vulnerability for a set duration.
    /// </summary>
    /// <param name="destroyComponent">The component that controls the player's vulnerability.</param>
    private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent)
    {
        destroyComponent.enabled = false; // Disable player vulnerability
        Debug.Log("Shield activated!");

        await Task.Delay((int)(durationShieldActive * 1000)); // Wait for the shield duration

        destroyComponent.enabled = true; // Re-enable player vulnerability
        Debug.Log("Shield deactivated.");
    }

    /// <summary>
    /// Spawns a shield pickup at a random position within the defined spawn area.
    /// </summary>
    public void SpawnShield()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2), 0f);
        Instantiate(shieldPickupPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Shield spawned at position: {spawnPosition}");
    }
}
