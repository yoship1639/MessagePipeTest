using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestSubscriber2 : MonoBehaviour
{
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
            Debug.Log($"time: {Time.realtimeSinceStartup.ToString("F2")}, index: {index}");
        }).AddTo(d);

        disposable = d.Build();
    }

    void OnDestroy()
    {
        disposable.Dispose();
    }
}