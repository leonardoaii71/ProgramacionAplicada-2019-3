using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssencesInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> essences;
    public GameObject Trap;
     GameObject newObject;
    float trapRate = 0.1f;
    const float startingSeconds = 1f, repeatingSeconds = 0.8f;
    void Start()
    {
        InvokeRepeating("InstantiateObject", startingSeconds, repeatingSeconds);
    }

    // Update is called once per frame
   void InstantiateObject(){
        if (Random.Range(0f, 1f) <= trapRate)
            newObject = Trap;
        else
            newObject = essences[Random.Range(0,6)];
        
        Instantiate(newObject, new Vector3(0, Random.Range(-3.6f, 5.8f), 0), Quaternion.identity);
        trapRate *= 1.01f;
   }
}
