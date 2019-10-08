using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 deltaPos;
    public float Speed = 10f;
    public float LeftLimit = -9, RightLimit = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0f); 
    
        transform.Translate(deltaPos);
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
                transform.position.y, 
                 transform.position.z);
    }
}
