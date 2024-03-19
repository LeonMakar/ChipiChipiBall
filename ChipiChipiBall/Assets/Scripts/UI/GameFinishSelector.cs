using UnityEngine;
using Zenject;

public class GameFinishSelector : MonoBehaviour
{
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _gameLoosePanel;
    [SerializeField] private GameObject _simpleTip;
    [SerializeField] private GameObject _nextLevelTip;
    [SerializeField] private GameObject _restartTip;

    private MediaMaterialController _media;

    [Inject]
    public void Construct(MediaMaterialController webPlayer)
    {
        _media = webPlayer;
    }
    public void SetGameFinishState(bool isPlayerWin)
    {
        if (isPlayerWin)
        {
            _gameWinPanel.SetActive(true);
            _media.SetClipOnGameOver(true);
            _simpleTip.SetActive(false);
            _nextLevelTip.SetActive(true);
        }
        else
        {
            _gameLoosePanel.SetActive(true);
            _media.SetClipOnGameOver(false);
            _simpleTip.SetActive(false);
            _restartTip.SetActive(true);
        }
    }
}
