using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("gameovercheck1");
        // if (other.tag == triggeringTag && enabled) {
        //             Debug.Log("gameovercheck2");

        //  PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        // if (playerHealth != null)
        // {
        //             Debug.Log("gameovercheck3");

        //     playerHealth.TakeDamage(); // הפחתת חיים במקום לסיים את המשחק מיד
        // }
        // }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }

}
