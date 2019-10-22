using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Vector3 dragStartPoint;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
       

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPoint = worldPoint;
        lineRenderer.SetPosition(0, dragStartPoint);
    }


    public void SetEndPoint(Vector3 worldPoint)
    {
        
        Debug.DrawLine(dragStartPoint, worldPoint, Color.yellow);
        //Debug.DrawLine(Vector3.zero, pointOffset, Color.blue);
        //Debug.DrawLine(Vector3.zero, endPoint, Color.yellow);


        lineRenderer.SetPosition(1, worldPoint);
    }
}

