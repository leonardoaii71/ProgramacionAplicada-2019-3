using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    private int blue_score, red_score, purpleDiamon_score, pinkDiamond_score, orange_score, diamond_score;
    public TextMeshPro blue_text;
    public TextMeshPro red_text;
    public TextMeshPro purpleDiamond_text;
    public TextMeshPro pinkDiamond_text;
    public TextMeshPro orange_text;
    public TextMeshPro diamond_text;

    public enum ScoreType{
        blue,
        red,
        purpleDiamond,
        pinkDiamond,
        orange,
        diamond,
        Enemy,
        Life,
        All
    }
    
    // Start is called before the first frame update


    void Start()
    {
      UpdateScoreText(ScoreType.All);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScoreText(ScoreType scoreType){
        if (scoreType == ScoreType.All || scoreType == ScoreType.blue)
        {
            blue_text.text = blue_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.orange)
        {
            orange_text.text = orange_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.pinkDiamond)
        {
            pinkDiamond_text.text = pinkDiamond_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.purpleDiamond)
        {
            purpleDiamond_text.text = purpleDiamon_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.red)
        {
            red_text.text = red_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.diamond)
        {
            blue_text.text = diamond_score.ToString();
        }
    }
    public void updateScore(ScoreType scoreType, int value=1){

           switch (scoreType)
           {
               case ScoreType.blue:
                    blue_score += value;
                    UpdateScoreText(ScoreType.blue);
                    break;
               case ScoreType.red:
                    blue_score++;
                    UpdateScoreText(ScoreType.red);
                    break;
               case ScoreType.orange:
                    blue_score += value;
                    UpdateScoreText(ScoreType.orange);
                    break;
               case ScoreType.diamond:
                    blue_score += value;
                    UpdateScoreText(ScoreType.diamond);
                    break;
               case ScoreType.pinkDiamond:
                    blue_score += value;
                   UpdateScoreText(ScoreType.pinkDiamond);
                    break;
               case ScoreType.purpleDiamond:
                    blue_score += value;
                    UpdateScoreText(ScoreType.purpleDiamond);
                    break;
                default:
                    break;
           }
            
    }

}
    

