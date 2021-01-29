using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : IScoreSender, IScoreReceiver, IResetable
{
    int score = 0;

    Action<int> scoreReceiver;

    public void AddScoreReceiver(Action<int> action)
    {
        scoreReceiver = action;
    }

    public Action<int> GetScoreReceiver()
    {
        return ReceiveScore;
    }

    public void ReceiveScore(int delta)
    {
        score += delta;
        scoreReceiver(score);
    }

    public void Reset()
    {
        ReceiveScore(-score);
    }
}
