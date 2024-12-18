using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // דרוש לעבודה עם UI
public class PlayerHealth : MonoBehaviour
{
    public int maxLives;
    public int currentLives;

    public Image[] hearts; // מערך של תמונות הלבבות
    //public Sprite fullHeart; // Sprite של לב מלא 

    private void Start()
    {
        Debug.Log($"Elioz: Start function start in player health of this object: {this.name}");
        currentLives = maxLives; // לאתחל את החיים להתחלה
        UpdateHearts();
    }

    public void TakeDamage()
    {
        currentLives--; // הפחתת חיים
        UpdateHearts();
        Debug.Log("Player took damage! Lives left: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver(); // מעבר ל-"Game Over" אם החיים נגמרו
        }
    }

    public void AddHealth(int amount)
    {
        currentLives += amount;

        // וידוא שלא עולים מעבר למקסימום חיים
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }

        UpdateHearts(); // עדכון התצוגה של הלבבות
        Debug.Log("Health added! Current lives: " + currentLives);
    }


    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // הלב גלוי
            }
            else
            {
                hearts[i].enabled = false; // הלב מוסתר
            }
        }
        Debug.Log($"Elioz: Start function UpdateHearts of this object: {this.name}");
        Debug.Log($"Elioz: current lives: " + currentLives);


    }


    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("level-game-over"); // כאן השם של סצנת ה-"Game Over"
        // Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false; // אם מריצים בעורך
        //                                                  // Error on editor 2021.3 what is it ? to check (Elioz)

    }
}
