using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputRenderer : MonoBehaviour, IScoreReceiver, IStateReceiver, IResetable, IResetterReceiver
{
    public Text score;
    public GameObject win;
    public GameObject fail;

    IResetter resetter;

    public Action<int> GetScoreReceiver()
    {
        return SetScore;
    }

    public Action<GameState> GetStateReceiver()
    {
        return SetState;
    }

    public void Reset()
    {
    }

    public void ResetState()
    {
        SetState(GameState.PLAYING);
    }
    public void ResetAll()
    {
        resetter.ResetAll();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void SetScore(int inScore)
    {
        score.text = inScore.ToString();
    }

    void SetState(GameState inState)
    {
        if (inState == GameState.WIN)
        {
            win.SetActive(true);
            Invoke("ResetState", 3f);
        }
        if (inState == GameState.FAIL)
        {
            fail.SetActive(true);
            Invoke("ResetState", 3f);
            Invoke("ResetAll", 3f);
        }
    }

    public void SetResetter(IResetter resetter)
    {
        this.resetter = resetter;
    }
}
