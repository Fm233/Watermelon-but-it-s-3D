using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stopwatch = System.Diagnostics.Stopwatch;

public class FruitStandardA : FruitStandard
{
    public Color color;
    public GameObject particle;
    public AudioClip breakClip;
    public bool emergeable = true;

    int level;
    Action<int> scoreReceiver;
    Action<Vector3, int> spawnReceiver;
    Action<AudioClip> audioReceiver;
    Action<GameState> stateReceiver;
    bool dead = false;
    Stopwatch timer = new Stopwatch();
    float scale;


    private void Start()
    {
        timer.Start();
        scale = transform.localScale.x;
        StartCoroutine(AnimStart());
    }

    IEnumerator AnimStart()
    {
        for (float i = 0.2f; i < 1f; i += 0.2f)
        {
            transform.localScale = Vector3.one * i * scale;
            yield return null;
        }
        transform.localScale = Vector3.one * scale;
    }

    public override void AddScoreReceiver(Action<int> action)
    {
        scoreReceiver += action;
    }

    public override void AddSpawnReceiver(Action<Vector3, int> action)
    {
        spawnReceiver += action;
    }

    public override void Break()
    {
        GameObject particleInstance = Instantiate(particle, transform.position, transform.rotation);
        particleInstance.transform.parent = transform.parent;
        var main = particleInstance.GetComponent<ParticleSystem>().main;
        main.startColor = color;
        audioReceiver(breakClip);
        dead = true;
        gameObject.SetActive(false);
    }

    public override FruitStandardModel GetFruit()
    {
        return new FruitStandardModel(level);
    }

    public override Action<FruitStandardModel> GetFruitReceiver()
    {
        return ReceiveFruit;
    }

    public void ReceiveFruit(FruitStandardModel fruit)
    {
        level = fruit.level;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!dead && emergeable)
        {
            if (other.collider.TryGetComponent(out FruitStandard fruit))
            {
                int otherLevel = fruit.GetFruit().level;
                if (otherLevel == level)
                {
                    if (otherLevel == 9)
                    {
                        stateReceiver(GameState.WIN);
                    }
                    spawnReceiver(other.GetContact(0).point, otherLevel + 1);
                    scoreReceiver(GetScore());
                    fruit.Break();
                    Break();
                }
            }
        }
    }

    int GetScore()
    {
        int score = 1;
        for (int i = 0; i < level; i++)
        {
            score *= 2;
        }
        return score;
    }

    public override float GetTime()
    {
        return timer.ElapsedMilliseconds / 1000f;
    }

    public override void Hide(bool state)
    {
        GetComponent<Collider>().enabled = !state;
    }

    public override Color GetColor()
    {
        return color;
    }

    public override void AddAudioReceiver(Action<AudioClip> action)
    {
        audioReceiver += action;
    }

    public override void AddStateReceiver(Action<GameState> action)
    {
        stateReceiver += action;
    }
}
