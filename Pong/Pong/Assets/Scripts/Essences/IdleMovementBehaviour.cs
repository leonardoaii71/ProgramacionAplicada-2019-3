using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovementBehaviour : MonoBehaviour
{
    float accelarationX = -9.8f, currentSpeedX;
    const float startPositionX = 10f;
    Vector3 _detalPos;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeedX = 0;
        transform.position = new Vector3(startPositionX, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _detalPos = new Vector3(currentSpeedX * Time.deltaTime + (accelarationX * Mathf.Pow(Time.deltaTime, 2) / 2), 0);
        currentSpeedX += accelarationX * Time.deltaTime;
        transform.Translate(_detalPos);
    }

}