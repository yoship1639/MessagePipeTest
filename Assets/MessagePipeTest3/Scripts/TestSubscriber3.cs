using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestSubscriber3 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    ISubscriber<DateTime> TimeSubscriber { get; set; }

    private IDisposable disposable;

    void Start()
    {
        var d = DisposableBag.CreateBuilder();

        // IPublisher<DateTime>から発行されたTimeを出力
        TimeSubscriber.Subscribe(time =>
        {
            Debug.Log($"time: {time}");
        }).AddTo(d);

        disposable = d.Build();
    }

    void OnDestroy()
    {
        disposable.Dispose();
    }
}