using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{

    private AudioSource backGroundSound;
   
    void Start()
    {
        backGroundSound = GetComponent<AudioSource>();
        backGroundSound.Play();
    }

    // Update is called once per frame
    public void MuteSoundButton()
    {
        if (backGroundSound.isPlaying)
        {
            backGroundSound.Pause();
        }
        else
        {
            backGroundSound.Play();
        }
    }
}
