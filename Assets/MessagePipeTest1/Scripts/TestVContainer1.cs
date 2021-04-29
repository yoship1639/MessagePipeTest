using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestVContainer1 : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipeを登録
        var options = builder.RegisterMessagePipe();
        
        // IPublisher<int>, ISubscriber<int>にInject
        builder.RegisterMessageBroker<int>(options);

        try
        {
            // ヒエラルキーにあるIPublisher<int>コンポーネントを登録
            builder.RegisterComponentInHierarchy<TestPubSub1>();
        }
        catch (Exception ex)
        {
            // ヒエラルキーに存在しない場合
            Debug.LogError(ex);
        }
    }
}
