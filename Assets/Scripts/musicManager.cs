using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void StartPlaying(AudioSource audio){
        audio.Play();
    }

    public void StopPlaying(AudioSource audio){
        audio.Stop();
    }
}
