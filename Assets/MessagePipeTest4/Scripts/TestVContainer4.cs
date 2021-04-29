using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestVContainer4 : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipeを登録
        var options = builder.RegisterMessagePipe();
        
        // IAsyncPublisher<DateTime>, ISubscriber<DateTime>にInject
        builder.RegisterMessageBroker<DateTime>(options);

        try
        {
            // ヒエラルキーにあるIPublisher<DateTime>コンポーネントを登録
            builder.RegisterComponentInHierarchy<TestPublisher4>();

            // ヒエラルキーにあるISubscriber<DateTime>コンポーネントを登録
            builder.RegisterComponentInHierarchy<TestSubscriber4>();
        }
        catch (Exception ex)
        {
            // ヒエラルキーに存在しない場合
            Debug.LogError(ex);
        }
    }
}
