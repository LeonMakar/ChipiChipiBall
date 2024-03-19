using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class LvlChanger : MonoBehaviour
{
    private int _currentSceneIndex;
    private Saver _saver;
    private Loader _loader;
    public bool IsMenu;

    [Inject]
    private void Construct(Saver saver, Loader loader)
    {
        _saver = saver;
        _loader = loader;
    }
    private void Awake()
    {
        YandexGame.RewardVideoEvent += RewardChangeLvl;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void RewardChangeLvl(int obj)
    {
        ChangeToNextScene();
    }

    public void ChangeToNextScene()
    {
        BallsController.BALLS_COUNT = 0;
        if (!IsMenu)
            _saver.SaveCompletedScene(_currentSceneIndex);
        SceneManager.LoadScene(YandexGame.savesData.NextLvlID);
    }
    public void RestartScene()
    {
        BallsController.BALLS_COUNT = 0;
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
