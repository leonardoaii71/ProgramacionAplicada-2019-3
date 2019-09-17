using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    float startingForceScalar = 10f;
    float movementSpeed = 0.3f;
    Vector3 startingForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.parent != null)
        {
            startingForce = Vector3.zero;
            startingForce.x = transform.parent.name == "Player1" ? -1 : 1;
            startingForce.y = Random.Range(0, 2) == 0 ? 1 : -1;
            
            startingForce *= startingForceScalar;

            transform.SetParent(null);
            //gameObject.GetComponent<Rigidbody>().velocity = movementSpeed;


        }
    }
}
