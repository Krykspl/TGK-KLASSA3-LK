using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrack : MonoBehaviour
{

    public AudioClip[] Soundtracks;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Soundtracks[Random.Range(0, Soundtracks.Length - 1)];
            AS.Play();
        }
    }
}