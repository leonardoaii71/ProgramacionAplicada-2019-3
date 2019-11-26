using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
public class GameOptionsLoader : MonoBehaviour
{
    
   string localPath = "gameOptions.xml";
   
    private void Start() {
        LoadGameOptions();
        Debug.Log(PlayerPrefs.GetString("PlayerName", ""));
    }

    public void SaveGameOptions(){
        GameOptions.Instance.ToString();
       using(Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + 
       localPath, FileMode.Create))
       {
           DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
           dataContract.WriteObject(fileStream, GameOptions.Instance);
       }

    }

     public void LoadGameOptions(){
         GameOptions.Instance.ToString();
        using (Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + localPath, FileMode.Open))
        {
            DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
            GameOptions.Instance = (GameOptions)dataContract.ReadObject(fileStream);
            
        }

    }


    
}
