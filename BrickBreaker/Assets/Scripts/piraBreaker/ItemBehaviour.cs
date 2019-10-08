using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private int count = 0;
    LevelScript levelscript;

    // Start is called before the first frame update
    private void Awake() {
        levelscript =  GameObject.Find("Scripts Globales").GetComponent<LevelScript>();
    }
    
    void Start()
    {
        if (gameObject.tag == "hard")
        {
            count = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
           count--;
           if (count <= 0)
           {
            Destroy(gameObject);
            levelscript.IncrementarScore();
           }
           
       }
        

}
