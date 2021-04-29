using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;
using UniRx;
using System;

public class TestPublisher3 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    IPublisher<DateTime> TimePublisher { get; set; }

    [SerializeField]
    private Button publishButton = null;

    void Start()
    {
        // PublishボタンをおしたらTimeを発行
        publishButton.OnClickAsObservable().Subscribe(_ =>
        {
            TimePublisher.Publish(DateTime.Now);
        }).AddTo(this);
    }
}