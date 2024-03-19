
using UnityEngine;
using UnityEngine.Video;

public class WebVideoPlayer : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public void PlayVideo(string videoName)
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
