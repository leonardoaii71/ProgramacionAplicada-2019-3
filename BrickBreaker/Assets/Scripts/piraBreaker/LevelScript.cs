using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
   public GameObject ball;
   public GameObject playah;
    public int score = 0;
    public int lives = 3;
    public bool isPlaying = false;
    public TextMesh ScoreText, LivesText, playingTime;
    // Start is called before the first frame update
    private void Start() {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
        playingTime.text = "Time: " + Time.timeSinceLevelLoad.ToString("0.0");
    }

    public void IncrementarScore(){
        this.score++;
        this.ScoreText.text = score.ToString();
    }

    public void updateLives(){
        lives--;
        LivesText.text = "Lives: " + lives;
    }

    public void SpawnBall(){
        if (lives > 0)
        {
        GameObject newBall = Instantiate(ball, new Vector3(0f, -1f, 0f), Quaternion.identity);
        newBall.transform.parent = playah.transform;
            
        }
        
    }
}
