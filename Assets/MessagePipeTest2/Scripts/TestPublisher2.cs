using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestPublisher2 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    IPublisher<int> IndexPublisher { get; set; }

    void Start()
    {
        UniTask.Run(async () =>
        {
            var index = 0;

            // 適当に無限ループ
            while (true)
            {
                // 1秒待機
                await UniTask.Delay(1000);

                // Indexを発行
                IndexPublisher.Publish(index++);
            }
        }).Forget();
    }
}