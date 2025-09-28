using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void Play()
    {
        Debug.Log("play sound");
        sound.Play();
    }

    public void Stop()
    {
        Debug.Log("stop sound");
        sound.Stop();
    }
}
