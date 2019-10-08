using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingControler : MonoBehaviour
{
    float currentPosition, scrollingSpeed = 0.3f;
    MeshRenderer MeshRenderer;
    private void Awake() {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += scrollingSpeed * Time.deltaTime; 
        MeshRenderer.material.mainTextureOffset = new Vector2(currentPosition, 0);
;    }
}
