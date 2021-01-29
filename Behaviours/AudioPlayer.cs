using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour, IAudioPlayer
{
    public AudioSource source;

    public Action<AudioClip> GetAudioReceiver()
    {
        return (AudioClip clip) =>
        {
            source.PlayOneShot(clip);
        };
    }
}
