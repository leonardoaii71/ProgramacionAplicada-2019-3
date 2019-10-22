using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballCollector : MonoBehaviour
{
    private BallFirer ballFirer;

    private void Awake()
    {
        ballFirer = FindObjectOfType<BallFirer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if (other.tag == "item"){
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }

        ballFirer.ReturnBall();
        other.gameObject.SetActive(false);
        
    }
}
