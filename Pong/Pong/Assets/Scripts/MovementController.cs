using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 movementSpeed = new Vector3(10, 10), deltaPos;
    Vector3 runningSpeed = new Vector3(15, 15);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire3"))
            deltaPos = new Vector3(runningSpeed.x * Input.GetAxis("Horizontal"), 
            runningSpeed.y * Input.GetAxis("Vertical"));
        else
            deltaPos = new Vector3(movementSpeed.x * Input.GetAxis("Horizontal"), 
            movementSpeed.y * Input.GetAxis("Vertical"));

            deltaPos *= Time.deltaTime;
            gameObject.transform.Translate(deltaPos);
    }
}
