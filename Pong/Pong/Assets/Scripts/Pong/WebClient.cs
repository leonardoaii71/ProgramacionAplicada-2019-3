using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebClient : MonoBehaviour
{
    string url = "https://localhost:8080/api/Scores";
    

    // Start is called before the first frame update

    private class Score {

        public int IdScore;
        public string PlayerName;
        public double score;
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Debug.Log("f6");
            StartCoroutine("SendGetRquest");
        }
         if (Input.GetKeyDown(KeyCode.F7))
        {
            Debug.Log("f7");
            StartCoroutine("SendPutRequest");
        }
    }

    IEnumerator SendGetRquest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler.text);
        }
    }

    IEnumerator SendPutRequest()
    {
        Score newScore = new Score { IdScore = 1, PlayerName = "Leonardo", score = 5 };
        UnityWebRequest www = UnityWebRequest.Put(url, JsonUtility.ToJson(newScore));
        www.SetRequestHeader("content-type", "application/json");

        yield return www.downloadHandler.text;

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
        
    }

   
}
