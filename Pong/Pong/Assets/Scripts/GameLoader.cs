using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    
  private void OntriggerStay(Collider other) {
      Debug.Log("triggered");
      if (!Input.GetButtonDown("Fire2"))
        return;
    
      switch(gameObject.name){
        case "PongScene":
            SceneManager.LoadScene("Pong");
            break;
        case "EssenceScene":
            SceneManager.LoadScene("Essences");
            break;
        default:
            break;

      }
    
  }
}
