﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x,
        Mathf.Clamp(player.transform.position.y, -2.3f, 2.3f),
        gameObject.transform.position.z);
    }
}