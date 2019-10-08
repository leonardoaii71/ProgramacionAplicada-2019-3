using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviours : MonoBehaviour {

    public bool? isLeftPlayer;
    
    float _startingSpeed = 7f;
    float startingForceScalar = 10f;
    Vector3 startingForce;

	
	// Update is called once per frame
	void Update()
    {
        if (transform.parent != null && Input.GetButtonDown("Fire1"))
        {
            //start playing
			startingForce = Vector3.zero;
			startingForce.x = transform.parent.name == "LeftPlayer" ? -1 : 1;
			startingForce.y = Random.Range(0,2) == 0 ? 1 : -1;
			startingForce *= startingForceScalar;
			transform.SetParent(null);

			gameObject.GetComponent<Rigidbody>().velocity = startingForce;
        }        
    }


}
