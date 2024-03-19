using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using YG;

[RequireComponent(typeof(VideoPlayer))]
public class MediaMaterialController : MonoBehaviour
{
    [SerializeField] private string _positiveClip;
    [SerializeField] private string _negativeClip;
    [SerializeField] private string _looseClip;
    [SerializeField] private string _winClip;

    [SerializeField] private GameObject[] _buttonsPhone;


    [SerializeField] private WebVideoPlayer _playerVideo;

    public bool CanPlayPositiveClip;
    private bool _positiveClipStarted;
    private bool _gameActive = true;
    private float deviceFPS;

    private void CalculateDeviceVideoSpeed()
    {
        Debug.Log(YandexGame.EnvironmentData.deviceType);
        if (YandexGame.EnvironmentData.deviceType == "desktop")
        {
            _playerVideo.VideoPlayer.playbackSpeed = 1;

            foreach (var item in _buttonsPhone)
                item.SetActive(false);
        }
        else
        {
            _playerVideo.VideoPlayer.Prepare();
            _playerVideo.VideoPlayer.playbackSpeed = 1f;

            foreach (var item in _buttonsPhone)
                item.SetActive(true);

        }

    }
    private void Awake()
    {
        YandexGame.GetDataEvent += CalculateDeviceVideoSpeed;

    }
    void Start()
    {
        if (YandexGame.EnvironmentData != null)
            if (YandexGame.EnvironmentData.deviceType == "desktop")
            {

                _playerVideo.VideoPlayer.playbackSpeed = 1;

                foreach (var item in _buttonsPhone)
                    item.SetActive(false);
            }
            else
            {
                _playerVideo.VideoPlayer.playbackSpeed = 1f;

                foreach (var item in _buttonsPhone)
                    item.SetActive(true);
            }
        _playerVideo.VideoPlayer.Prepare();
        _playerVideo.PlayVideo(_negativeClip);
        CheckClipBehaviorAsync().Forget();
    }
    public void SetClipOnGameOver(bool isPlayerWin)
    {
        _gameActive = false;
        if (isPlayerWin)
        {
            _playerVideo.VideoPlayer.Prepare();
            _playerVideo.PlayVideo(_winClip);
        }
        else
        {
            _playerVideo.VideoPlayer.Prepare();
            _playerVideo.PlayVideo(_looseClip);
        }
    }
    public void ChangeClip()
    {
        if (CanPlayPositiveClip && !_positiveClipStarted)
        {
            _positiveClipStarted = true;
            _playerVideo.VideoPlayer.Prepare();
            _playerVideo.PlayVideo(_positiveClip);
        }
        else if (!CanPlayPositiveClip && _positiveClipStarted)
        {
            _positiveClipStarted = false;
            _playerVideo.VideoPlayer.Prepare();
            _playerVideo.PlayVideo(_negativeClip);
        }
    }

    private async UniTaskVoid CheckClipBehaviorAsync()
    {
        while (_gameActive)
        {
            CanPlayPositiveClip = false;
            await UniTask.Delay(2000);
            if (_gameActive)
                ChangeClip();
        }
    }
}
