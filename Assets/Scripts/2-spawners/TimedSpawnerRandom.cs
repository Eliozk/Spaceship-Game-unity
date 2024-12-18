using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This component instantiates a given prefab at random time intervals and random positions within a specified range.
/// </summary>
public class TimedSpawnerRandom : MonoBehaviour
{
    /// <summary>
    /// The prefab to spawn.
    /// </summary>
    [SerializeField] private Mover prefabToSpawn;

    /// <summary>
    /// The velocity to assign to the spawned objects.
    /// </summary>
    [SerializeField] private Vector3 velocityOfSpawnedObject;

    /// <summary>
    /// The minimum time interval between consecutive spawns, in seconds.
    /// </summary>
    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField] private float minTimeBetweenSpawns = 0.2f;

    /// <summary>
    /// The maximum time interval between consecutive spawns, in seconds.
    /// </summary>
    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField] private float maxTimeBetweenSpawns = 1.0f;

    /// <summary>
    /// The maximum horizontal distance from the spawner to the spawned objects, in meters.
    /// </summary>
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")]
    [SerializeField] private float maxXDistance = 1.5f;

    /// <summary>
    /// The parent transform to organize all spawned instances under.
    /// </summary>
    [SerializeField] private Transform parentOfAllInstances;

    private void Start()
    {
        SpawnRoutine();
    }

    /// <summary>
    /// A coroutine-like routine to spawn objects at random intervals and positions.
    /// </summary>
    private async void SpawnRoutine()
    {
        while (true)
        {
            // Calculate a random time interval between spawns.
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds); // Wait for the interval.

            // Check if this object has been destroyed.
            if (!this) break;

            // Calculate a random position for the spawned object.
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, maxXDistance),
                transform.position.y,
                transform.position.z);

            // Instantiate the prefab at the calculated position.
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);

            // Set the velocity of the spawned object.
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);

            // Assign the spawned object to the specified parent transform.
            newObject.transform.parent = parentOfAllInstances;
        }
    }
}
