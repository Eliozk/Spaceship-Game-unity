
# Spaceship-Game-unity

# יוניטי שבוע 2: אלמנטים פורמליים

פרויקט המדגים שלב-אחר-שלב אלמנטים פורמליים בפיתוח משחקים ביוניטי, כולל:

* Prefabs ליצירת אובייקטים חדשים;
* Colliders ליצירת אינטראקציות עם תוצאות שונות;
* Coroutines ליצירת חוקים מבוססי זמן.

הסברים טקסטואליים זמינים 
[כאן](https://github.com/gamedev-at-ariel/gamedev-5782) בתיקייה 04.

לכניסה למשחק תצוגה בסיסי: [Spaceship Game on Itch.io](https://kolanieliozgmailcom.itch.io/spaceship-game)


## שכפול הפרויקט
כדי לשכפל את הפרויקט, ייתכן שתצטרך להתקין את `git lfs` (אם הוא לא מותקן כבר):

```bash
git lfs install
```

כדי לשכפל מהר יותר, ניתן להגביל את עומק השכפול ל-1 כך:

```bash
git clone --depth=1 https://github.com/<repository-name>.git
```

כאשר תפתח את הפרויקט לראשונה, ייתכן שלא תראה טקסט בשדה הניקוד.
הסיבה לכך היא ש-`TextMeshPro` לא נמצא בפרויקט.
עורך יוניטי אמור להציג חלונית שמציעה לייבא את TextMeshPro;
לאחר שתייבא אותו, פתח מחדש את הסצנות ותוכל לראות את הטקסטים.

## קבצי הסקריפטים
ניתן למצוא את הסקריפטים של המשחק בקישור הבא:  
[סקריפטים לפרויקט](https://github.com/Eliozk/Spaceship-Game-unity/tree/main/Assets/Scripts)

### הסברים על הסקריפטים:
1. **InputMover.cs**  
   סקריפט שמאפשר לשלוט בתנועת השחקן באמצעות מקשי המקלדת. 
   
2. **TimedSpawner.cs**  
   סקריפט שאחראי על יצירת אובייקטים חדשים (כמו אויבים) בצורה מחזורית לאחר פרקי זמן קבועים.

3. **CollisionLogger.cs**  
   סקריפט המאפשר רישום אינטראקציות בין אובייקטים (למשל, התנגשות).

4. **GameOverOnTrigger2D.cs**  
   סקריפט שמסיים את המשחק כאשר אובייקט השחקן נתקל באובייקט מסוים.

5. **ScoreAdder.cs**  
   סקריפט שמעדכן את הניקוד של השחקן בעקבות פעולות במשחק.

6. **GotoNextLevel.cs**  
   סקריפט המעביר את השחקן לשלב הבא ברגע שמושג יעד מסוים.

## קרדיטים

### תכנות:
* מאוז גרוסמן
* אראל סגל-הלוי

### קורסים מקוונים:
* [המדריך האולטימטיבי לפיתוח משחקים ביוניטי 2019](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity/), מאת ג'ונתן וינברגר

### גרפיקה:
* [מאט ווייטהד](https://ccsearch.creativecommons.org/photos/7fd4a37b-8d1a-4d4c-80a2-4ca4a3839941)
* [ערכת החלל של Kenney](https://kenney.nl/assets/space-kit)
* [חלליות דו-ממדיות מונפשות של Ductman](https://assetstore.unity.com/packages/2d/characters/2d-animated-spaceships-96852)
* [Franc מהפרויקט Noun](https://commons.wikimedia.org/w/index.php?curid=64661575)
* [Greek-arrow-animated.gif מאת Andrikkos תחת רישיון CC BY-SA 3.0](https://search.creativecommons.org/photos/2db102af-80d0-4ec8-9171-1ac77d2565ce)
