using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public AudioSource PongSound;
   public AudioSource GameStartSound;
   public AudioSource ScoreSentSound;
   
    public void PlayPongSound(){
       PongSound.Play();
    }

    public void PlayGameStartSound(){
       PongSound.Play();
    }

    public void PlayScoreSentSound(){
       PongSound.Play();
    }
    
}