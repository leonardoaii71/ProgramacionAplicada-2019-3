using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{

    public SpriteRenderer sprite;
    TextMeshPro text;
    public int count;
    public bool wasHit = false;
    public GameObject particles;
    AudioSource audioSource;


    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        
        text = GetComponentInChildren<TextMeshPro>();
        audioSource = GetComponent<AudioSource>();

    }


    public void setCount(int count)
    {
        this.count = count;
        updateCountText();

    }

    void updateCountText()
    {
        text.SetText(count.ToString());
        sprite.color = Color.Lerp(Color.white, Color.red, this.count / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            audioSource.Play();
            count--;
            if (count > 0)
            {
                updateCountText();
            }
            else
            {
                
                GetComponent<SpriteRenderer>().enabled = false; 
                GetComponent<Collider2D>().enabled = false;
                Destroy(transform.GetChild(0).gameObject);
                GetComponent<ParticleSystem>().Play();
                
               
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        wasHit = true;
        if (gameObject.name == "diffuser")
        {
            GetComponent<AreaEffector2D>().forceAngle = Random.Range(0f, 180);
        }
        
    }
   
}
