using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void playSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

}

//AudioListener.pause=true; is used to pause all the AudioClips
//AudioSource.ignoreListenerPause=true; used with a specific audio to ignore the pause command