using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isPlayerOne;
    float movementSpeed = 1f;
    const float lowerLimit = -3.4f, upperLimit = 3.4f;
    Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerOne = name == "player1";
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3();
       
    }
}
