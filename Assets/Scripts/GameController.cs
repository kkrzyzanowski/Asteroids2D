using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public GameObject[] asteroids;
    public Vector2 spawnPositions;
    public int asteroidsCounts;
    public float startWait;
    public float wait;
    public float spawnWait;
    private int score;
    private bool endgame;
    public Text scoreText;
    public GUIText gameover;
    public Text lifeText;
    bool isPlayerDown;
    
	// Use this for initialization
	void Start () {
        
        endgame = false;
        gameover.text = "";
        score = 0;
        UpdateGUIScore();
        UpdateLifes();
        StartCoroutine(spawnAsteroids());
        isPlayerDown = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

   public void UpdateScore(int scored)
    {
        score += scored;
        UpdateGUIScore();

    }
    void UpdateGUIScore()
    {
        int equal_score = Player.score + score;
        scoreText.text = "Score: " + equal_score;
    }
    void UpdateLifes()
    {
        lifeText.text = "x" + Player.lifes;
    }
    public void losing_life()
    {
        Player.lifes--;
        Player.score += score;
        isPlayerDown = true;

        UpdateLifes();

    }
    public void GameOver()
    { 
        if (Player.lifes == 0)
        {
            gameover.text = "Game Over!";
            endgame = true;
        }
    }
    void backToMenu()
    {
        Player.score = 0;
        Player.lifes = 3;
        SceneManager.LoadScene("Menu");
        for (int i = 0; i < Player.lifes; i++)
            Player.enabledImages[i] = true;
        
    }
    void resetLevel()
    {
         if (Player.lifes > 0)
                SceneManager.LoadScene("scene");
     }
    IEnumerator spawnAsteroids()
    {
        int level = 1;
        int valueToNextLevel = 10;
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0;i<asteroidsCounts; i++)
            {
                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
                int direction = Random.Range(0, 4);
                Quaternion rotations = Quaternion.identity;
                Vector2 moves = setDirectionPositions(direction);
                Instantiate(asteroid, moves, rotations);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wait);
            if(isPlayerDown)
            {
                //removeimage();
                yield return new WaitForSeconds(3);
                resetLevel();
            }
            if(endgame)
            {
                if(Player.score>PlayerPrefs.GetInt("Highscore"))
                     PlayerPrefs.SetInt("Highscore", Player.score);
                yield return new WaitForSeconds(startWait);
                backToMenu();
                break;
            }
            if(score/(valueToNextLevel* level)>=1)
            {
                level++;
                asteroidsCounts++;
                //AsteroidsMove.speed += 1.0f;
            }
            
        }
    }
    Vector2 setDirectionPositions(int direction)
    {
        Vector2 positions = new Vector2(0.0f, 0.0f);
        switch (direction)
        {
            case 0: 
                {
                   
                    positions = new Vector2(Random.Range(-spawnPositions.x, spawnPositions.x), spawnPositions.y);
                    return positions;
                }
            case 1:
                {
                   
                    positions = new Vector2(Random.Range(-spawnPositions.x, spawnPositions.x), -spawnPositions.y);
                    return positions;
                }
            case 2:
                {
                   
                    positions = new Vector2(spawnPositions.x, Random.Range(-spawnPositions.y, spawnPositions.y));
                    return positions;
                }
            case 3:
                {
                   
                    positions = new Vector2(-spawnPositions.x, Random.Range(-spawnPositions.y, spawnPositions.y));
                    return positions;
                }
          }
        return positions;
    }

   
}
