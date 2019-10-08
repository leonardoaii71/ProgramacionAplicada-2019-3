using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mover a deadzones
public class DeadZoneController : MonoBehaviour
{
public GameObject Ball;
public GameObject LeftPlayer, RightPlayer;
public int leftScore, rightScore;
public TextMesh leftScoreText, rightScoreText;
bool isLeftDeadZone;

    // Start is called before the first frame update
    void Start()
    {
        isLeftDeadZone = gameObject.name == "LeftDeadZone";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            incrementScore(!isLeftDeadZone);
            Ball.transform.SetParent(isLeftDeadZone ? RightPlayer.transform : LeftPlayer.transform);
            Ball.transform.localPosition = new Vector3(isLeftDeadZone ? -2.5f : 2.5f, 0);
        }
    }

    public void incrementScore(bool LeftDeadZone){
        if (LeftDeadZone)
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
        }
        else
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
        }
    }
}
