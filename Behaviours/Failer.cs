using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stopwatch = System.Diagnostics.Stopwatch;

public class Failer : MonoBehaviour, IStateSender, IRedSender, IResetable
{
    public bool deadly;
    public float deadTime;

    Stopwatch failTimer = new Stopwatch();
    Stopwatch stayTimer = new Stopwatch();
    Action<GameState> stateReceiver;
    Action<bool> redReceiver;
    bool failing = false;
    bool failed = false;

    private void Start()
    {
        stayTimer.Restart();
    }
    private void Update()
    {
        if (!failed)
        {
            if (stayTimer.ElapsedMilliseconds < 50 && !failTimer.IsRunning)
            {
                failTimer.Restart();
            }
            if (stayTimer.ElapsedMilliseconds >= 50 && failTimer.IsRunning)
            {
                failTimer.Restart();
                failTimer.Stop();
            }
            if (failTimer.ElapsedMilliseconds > 500 && !failing)
            {
                failing = true;
                redReceiver(true);
            }
            if (failTimer.ElapsedMilliseconds <= 500 && failing)
            {
                failing = false;
                redReceiver(false);
            }
            if (deadly && failTimer.ElapsedMilliseconds > deadTime * 1000)
            {
                failed = true;
                redReceiver(false);
                stateReceiver(GameState.FAIL);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IFruitAgeable fruit))
        {
            if (fruit.GetTime() > 1f)
            {
                stayTimer.Restart();
            }
        }
    }

    public void AddStateReceiver(Action<GameState> action)
    {
        stateReceiver += action;
    }

    public void AddRedReceiver(Action<bool> action)
    {
        redReceiver += action;
    }

    public void Reset()
    {
        stayTimer.Restart();
        failTimer.Restart();
        failTimer.Stop();
        failing = false;
        failed = false;
    }
}
