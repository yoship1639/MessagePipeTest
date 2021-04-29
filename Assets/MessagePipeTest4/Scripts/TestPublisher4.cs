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

public class TestPublisher4 : MonoBehaviour
{
    // VContainerにより自動的にInjectされる
    [Inject]
    IAsyncPublisher<DateTime> TimePublisher { get; set; }

    [SerializeField]
    private Button publishButton = null;

    void Start()
    {
        // Publishボタンをおしたら3回Timeを発行
        publishButton.OnClickAsObservable().Subscribe(async _ =>
        {
            publishButton.interactable = false;

            await TimePublisher.PublishAsync(DateTime.Now);
            await TimePublisher.PublishAsync(DateTime.Now);
            await TimePublisher.PublishAsync(DateTime.Now);

            publishButton.interactable = true;
        }).AddTo(this);
    }
}