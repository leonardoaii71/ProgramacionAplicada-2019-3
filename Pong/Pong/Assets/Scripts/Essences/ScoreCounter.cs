using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    private int blue_score = 0, red_score = 0, purpleDiamon_score = 0, pinkDiamond_score = 0, orange_score = 0, diamond_score = 0, life_score = 10;
    public TextMeshPro blue_text;
    public TextMeshPro red_text;
    public TextMeshPro purpleDiamond_text;
    public TextMeshPro pinkDiamond_text;
    public TextMeshPro orange_text;
    public TextMeshPro diamond_text;
    public TextMeshPro life_text;

    public enum ScoreType{
        blue,
        red,
        purpleDiamond,
        pinkDiamond,
        orange,
        diamond,
        enemy,
        Life,
        All
    }
    
    // Start is called before the first frame update
    void Start()
    {
      UpdateScoreText(ScoreType.All);
        
    }

    public int GetLifeScore(){
        return life_score;
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
            diamond_text.text = diamond_score.ToString();
        }
        if (scoreType == ScoreType.All || scoreType == ScoreType.Life)
        {
            life_text.text = life_score.ToString();
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
                    red_score++;
                    UpdateScoreText(ScoreType.red);
                    break;
               case ScoreType.orange:
                    orange_score += value;
                    UpdateScoreText(ScoreType.orange);
                    break;
               case ScoreType.diamond:
                    diamond_score += value;
                    UpdateScoreText(ScoreType.diamond);
                    break;
               case ScoreType.pinkDiamond:
                    pinkDiamond_score += value;
                   UpdateScoreText(ScoreType.pinkDiamond);
                    break;
               case ScoreType.purpleDiamond:
                    purpleDiamon_score += value;
                    UpdateScoreText(ScoreType.purpleDiamond);
                    break;
                case ScoreType.Life:
                    life_score += value;
                    UpdateScoreText(ScoreType.Life);
                    break;
                default:
                    break;
           }
            
    }

}
    

