using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;

public class TestPubSub1 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    IPublisher<int> IndexPublisher { get; set; }

    // VContainerにより自動的にInjectされる
    [Inject]
    ISubscriber<int> IndexSubscriber { get; set; }

    private IDisposable disposable;
    
    void Start()
    {
        var d = DisposableBag.CreateBuilder();

        // IPublisher<int>から発行されたIndexを出力
        IndexSubscriber.Subscribe(index =>
        {
            Debug.Log($"index: {index}");
        }).AddTo(d);

        // Indexを発行
        IndexPublisher.Publish(10);
        IndexPublisher.Publish(20);
        IndexPublisher.Publish(30);

        disposable = d.Build();
    }

    void OnDestroy()
    {
        disposable.Dispose();
    }
}
