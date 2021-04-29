using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestSubscriber4 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    IAsyncSubscriber<DateTime> TimeSubscriber { get; set; }

    private IDisposable disposable;

    void Start()
    {
        var d = DisposableBag.CreateBuilder();

        TimeMessageHandler4 handler = new TimeMessageHandler4();

        TimeSubscriber.Subscribe(handler).AddTo(d);

        disposable = d.Build();
    }

    void OnDestroy()
    {
        disposable.Dispose();
    }
}

class TimeMessageHandler4 : IAsyncMessageHandler<DateTime>
{
    public async UniTask HandleAsync(DateTime time, CancellationToken cancellationToken)
    {
        // 1秒待ってから出力
        await UniTask.Delay(1000);
        Debug.Log($"time: {time}");
    }
}