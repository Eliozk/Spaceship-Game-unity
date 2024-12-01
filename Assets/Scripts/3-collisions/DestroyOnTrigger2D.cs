using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag; // תג שמייצג את החפצים שפוגעים בחללית (לדוגמה, Enemy)

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Elioz: OnTriggerEnter2D activated with object: " + other.name);

        // התעלמות מהתנגשות עם יריות החללית
        if (other.name.Contains("Laser"))
        {
            Debug.Log("Elioz: Ignoring collision with object: " + other.name + " (Laser detected)");
            return;
        }
        
        if (other.tag == triggeringTag && enabled)//אם פוגע בחללית אובייקט
        {
            Debug.Log("Elioz: Object with correct tag found: " + other.name + " Tag: " + other.tag);

            // קבלת קומפוננטת PlayerHealth של השחקן
            PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

            if (playerHealth != null && !this.name.Contains("Laser"))
            {
                Debug.Log("Elioz: PlayerHealth component found on Player Spaceship, proceeding to TakeDamage");
                playerHealth.TakeDamage(); // הורדת חיים
            }
            Debug.Log("Elioz: Destroying other object: " + other.gameObject.name);
            Destroy(other.gameObject); // השמדת האובייקט המתנגש
        }
        else
        {
            Debug.Log("Elioz: Object " + other.name + " with tag " + other.tag + " did not match or script disabled.");
        }
    }
}
