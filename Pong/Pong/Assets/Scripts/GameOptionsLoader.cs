using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
public class GameOptionsLoader : MonoBehaviour
{

    private void Start() {
        LoadGameOptions();
        Debug.Log(PlayerPrefs.GetString("PlayerName", ""));
    }

   string localPath = "gameOptions.xml";
    public void SaveGameOptions(){
       using(Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + 
       localPath, FileMode.Create))
       {
           DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
           dataContract.WriteObject(fileStream, GameOptions.Instance);
       }

    }

     public void LoadGameOptions(){
       using(Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + 
       localPath, FileMode.Open))
       {
           DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
           dataContract.ReadObject(fileStream);
       }

    }


    
}
