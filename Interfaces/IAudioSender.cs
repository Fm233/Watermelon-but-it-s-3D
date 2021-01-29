using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioSender
{
    void AddAudioReceiver(Action<AudioClip> action);
}
