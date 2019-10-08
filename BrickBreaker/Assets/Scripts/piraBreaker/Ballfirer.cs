using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballfirer : MonoBehaviour
{
    public LevelScript levelscript;
    Vector3 direccion;
    float xSpeed = 10f;
    
     private void Awake() {
        levelscript =  GameObject.Find("Scripts Globales").GetComponent<LevelScript>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButtonDown("Fire1") && !levelscript.isPlaying){
             Fire();
         }

    }

    public void Fire(){
        direccion = new Vector3((Random.Range(0, 2) == 0 ? 1 : -1), 1);
        GetComponent<Rigidbody>().velocity = direccion * xSpeed ;
        transform.parent = null;
        levelscript.isPlaying = true;
    }
}
