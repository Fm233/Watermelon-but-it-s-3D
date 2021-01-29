using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public InputSenderPC inputSender;
    public InputSender inputSenderConstant;
    public FruitFactoryStandard fruitFactoryStandard;
    public OutputRenderer outputRenderer;
    public Failer preFailer;
    public Failer failer;
    public Redder redder;
    public AudioPlayer audioPlayer;
    public SpawnerStandard spawnerStandard;
    void Start()
    {
        StartStandard();
    }

    void StartStandard()
    {
        // App
        Application.targetFrameRate = 60;

        // Init
        ScoreAdder scoreAdder = new ScoreAdder();
        StateTrigger stateTrigger = new StateTrigger();
        CursorStandard cursorStandard = new CursorStandard();
        RandomProvider randomProvider = new RandomProvider();
        Resetter resetter = new Resetter();
        ParentProvider parentProvider = new ParentProvider();

        // Connect
        inputSender.AddSpawnReceiver(spawnerStandard.GetSpawnReceiver());
        inputSender.SetRandomProvider(randomProvider);
        inputSender.AddAudioReceiver(audioPlayer.GetAudioReceiver());
        inputSenderConstant.AddSpawnReceiver(cursorStandard.GetSpawnReceiver());
        inputSenderConstant.SetRandomProvider(randomProvider);
        spawnerStandard.ReceiveFactory(fruitFactoryStandard);
        cursorStandard.ReceiveFactory(fruitFactoryStandard);
        spawnerStandard.AddScoreReceiver(scoreAdder.GetScoreReceiver());
        spawnerStandard.AddAudioReceiver(audioPlayer.GetAudioReceiver());
        spawnerStandard.AddStateReceiver(stateTrigger.GetStateReceiver());
        spawnerStandard.SetParentProvider(parentProvider);
        scoreAdder.AddScoreReceiver(outputRenderer.GetScoreReceiver());
        stateTrigger.AddStateReceiver(outputRenderer.GetStateReceiver());
        preFailer.AddRedReceiver(redder.GetRedReceiver());
        failer.AddRedReceiver(redder.GetRedReceiver());
        failer.AddStateReceiver(stateTrigger.GetStateReceiver());
        outputRenderer.SetResetter(resetter);
        resetter.AddResetable(inputSender);
        resetter.AddResetable(inputSenderConstant);
        resetter.AddResetable(fruitFactoryStandard);
        resetter.AddResetable(outputRenderer);
        resetter.AddResetable(preFailer);
        resetter.AddResetable(failer);
        resetter.AddResetable(redder);
        resetter.AddResetable(scoreAdder);
        resetter.AddResetable(spawnerStandard);
        resetter.AddResetable(stateTrigger);
        resetter.AddResetable(cursorStandard);
        resetter.AddResetable(randomProvider);
        resetter.AddResetable(parentProvider);
    }
}
