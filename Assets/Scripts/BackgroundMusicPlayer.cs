using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
     public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicTracks.Length > 0)
        {
            PlayNextTrack();
        }
        else
        {
            Debug.LogError("No music tracks assigned.");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        audioSource.Stop();

        audioSource.clip = musicTracks[currentTrackIndex];

        audioSource.Play();

        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
    }

}
