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
        StartCoroutine(CheckClipBehaviorCoroutine());

    }

    public void ChangeClip()
    {
        if (CanPlayPositiveClip && !_positiveClipStarted)
        {
            _videoPlayer.clip = _positiveClip;
            _positiveClipStarted = true;
            _videoPlayer.Play();
            StartCoroutine(WaitLagsCoroutine());
        }
        else if (!CanPlayPositiveClip && _positiveClipStarted)
        {
            _videoPlayer.clip = _negativeClip;
            _positiveClipStarted = false;
            _videoPlayer.Play();
            StartCoroutine(WaitLagsCoroutine());
        }
      
    }

    private IEnumerator CheckClipBehaviorCoroutine()
    {
        while (true)
        {
            CanPlayPositiveClip = false;
            yield return new WaitForSeconds(2.0f);
            ChangeClip();
        }
    }

    private IEnumerator WaitLagsCoroutine()
    {
        _meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _meshRenderer.enabled = true;
    }


}
