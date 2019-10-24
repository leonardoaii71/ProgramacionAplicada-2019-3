using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallFirer : MonoBehaviour
{
    public GameObject ballPrefab;
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Vector3 direccion;

    public bool puedeInteractuar = true;
    public bool didClick = false;
    public float speed = 10f;

    private itemGenerator itemGenerator;
    private LaunchLine launchline;
    private List<GameObject> balls = new List<GameObject>();
    private int ballsReady;
    
    public TextMeshPro ballsCount;

    // Start is called before the first frame update
    public void Awake()
    {
        //todo refactor
        itemGenerator = FindObjectOfType<itemGenerator>();
        launchline = GetComponent<LaunchLine>();
        CreateBall();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition  = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * 5;

        if (Input.GetMouseButtonDown(0))
        {
            //posición inicial cuando se presiona el botón del mouse
            posicionInicial = mousePosition;
            launchline.SetStartPoint(transform.position);
            didClick = true;
        }
        else if (Input.GetMouseButton(0))
        {
            //cuando el botón está presionado
            posicionFinal = mousePosition;
            direccion = posicionFinal - posicionInicial;
            launchline.SetEndPoint(transform.position - direccion);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

 
    private void EndDrag()
    {
       
        StartCoroutine(IniciarDisparos());
    }

    IEnumerator IniciarDisparos()
    {
        direccion.Normalize();
        
        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().velocity = direccion * -speed;
            
            yield return new WaitForSeconds(0.05f);
        }
        ballsReady = 0;
        puedeInteractuar = false;
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        ball.SetActive(false);
        balls.Add(ball);
        ballsCount.SetText("x"+balls.Count.ToString());
        ballsReady++;
    }
    

    public void ReturnBall()
    {
        ballsReady++;
        //Debug.Log("ready: " + ballsReady.ToString());
        //si llegaron todas las bolas, crear nueva linea de bloques y nueva bola
        if (ballsReady == balls.Count)
        {
            itemGenerator.GenerateRowofBlocks();
            CreateBall();
            puedeInteractuar = true;
        }
    }

}
