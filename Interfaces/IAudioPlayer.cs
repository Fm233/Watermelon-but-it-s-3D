using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAudioPlayer
{
    Action<AudioClip> GetAudioReceiver();
}
