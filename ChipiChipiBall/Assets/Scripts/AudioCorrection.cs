using UnityEngine;
using UnityEngine.Video;

public class AudioCorrection : MonoBehaviour
{
    private VideoPlayer _player;
    private void Awake()
    {
        _player = GetComponent<VideoPlayer>();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus)
        {
            AudioListener.pause = false;
            _player.playbackSpeed = 1;
        }
        else
        {
            _player.playbackSpeed = 0;
            AudioListener.pause = true;
        }
    }
}
