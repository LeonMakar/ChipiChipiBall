using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class MediaMaterialController : MonoBehaviour
{
    [SerializeField] private VideoClip _positiveClip;
    [SerializeField] private VideoClip _negativeClip;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private MeshRenderer _meshRenderer;

    public bool CanPlayPositiveClip;
    private bool _positiveClipStarted;

    void Start()
    {
        StopAllCoroutines();
        _videoPlayer.clip = _negativeClip;
        _videoPlayer.Play();
        CheckClipBehaviorAsync().Forget();
    }

    public async UniTaskVoid ChangeClipAsync()
    {
        if (CanPlayPositiveClip && !_positiveClipStarted)
        {
            _videoPlayer.clip = _positiveClip;
            _positiveClipStarted = true;
            _videoPlayer.Play();
           await WaitLagsAsync();
        }
        else if (!CanPlayPositiveClip && _positiveClipStarted)
        {
            _videoPlayer.clip = _negativeClip;
            _positiveClipStarted = false;
            _videoPlayer.Play();
          await WaitLagsAsync();
        }

    }

    private async UniTaskVoid CheckClipBehaviorAsync()
    {
        while (true)
        {
            CanPlayPositiveClip = false;
            await UniTask.Delay(2000);
            ChangeClipAsync().Forget();
        }
    }

    private async UniTask WaitLagsAsync()
    {
        _meshRenderer.enabled = false;
        await UniTask.Delay(100);
        _meshRenderer.enabled = true;
    }


}
