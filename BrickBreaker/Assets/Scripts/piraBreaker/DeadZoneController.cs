using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    public LevelScript levelscript;
    public GameObject ball;
    
    
    // Start is called before the first frame update
    void Start()
    {
         levelscript =  GameObject.Find("Scripts Globales").GetComponent<LevelScript>();
    }

    private void OnCollisionEnter(Collision other) {
    
            Destroy(other.gameObject);
            levelscript.isPlaying = false;
            levelscript.updateLives();
            levelscript.SpawnBall();          

       }
}
