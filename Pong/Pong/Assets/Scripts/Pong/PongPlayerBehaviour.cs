using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerBehaviour : MonoBehaviour {
    
    public int UPPERLIMIT = 3, LOWERLIMIT = -3;
    public bool _isLeftPlayer;
    private float Speed = 10f;
    public Vector3 _deltaPos;
    public static bool _onePlayer;
    public GameObject _ball;
    Animator animator;
    ScoreCounter scoreCounter;

    public void Awake()
    {
        _isLeftPlayer = gameObject.name == "LeftPlayer";
        _ball = GameObject.Find("Ball");
        animator = GetComponent<Animator>();
        scoreCounter = GameObject.Find("LevelController").GetComponent<ScoreCounter>();
    }

	// Use this for initialization
	void Start () {
        _onePlayer = true;
	}
	

	// Update is called once per frame
	void Update () {
       
        if(_onePlayer && !_isLeftPlayer && _ball != null){
            transform.position = new Vector3(transform.position.x,
                                        Mathf.Lerp(_ball.transform.position.y, gameObject.transform.position.y, 0.95f), 
                                        transform.position.z);
             return;
        }
        if (animator != null)
        {
            animator.SetFloat("SpeedY", _deltaPos.y);
        }

        _deltaPos = new Vector3(0f, (
                _isLeftPlayer 
                 ? Input.GetAxis("LeftPlayer")
                 : Input.GetAxis("Vertical")) * Speed * Time.deltaTime);
                    
        transform.Translate(_deltaPos);
        transform.position = new Vector3(
                transform.position.x, 
                Mathf.Clamp(transform.position.y, LOWERLIMIT, UPPERLIMIT),
                 transform.position.z);
	
        }

    private void OnTriggerEnter(Collider other) {
        ScoreCounter.ScoreType scoreType;
        try
        {
            scoreType = (ScoreCounter.ScoreType)Enum.Parse(
            typeof(ScoreCounter.ScoreType),
            other.gameObject.tag);
            
        }
        catch (System.Exception)
        {   
            throw;
        }
        if (scoreType == ScoreCounter.ScoreType.enemy)
            scoreCounter.updateScore(ScoreCounter.ScoreType.Life, -1);
        else
            scoreCounter.updateScore(scoreType);

        Destroy(other.gameObject);
        /*if (scoreCounter.getLifeScore() <= 0)
        {
            Debug.Log("Game Over");
        }*/
    }
}
