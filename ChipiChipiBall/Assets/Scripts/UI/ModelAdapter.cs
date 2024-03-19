using EmeraldPowder.CameraScaler;
using System;
using UnityEngine;
using YG;

public class ModelAdapter : MonoBehaviour
{
    [SerializeField] CameraScaler _cameraScaler;


    void Awake()
    {
        YandexGame.GetDataEvent += ChekDevice;
    }

    private void ChekDevice()
    {
        if(YandexGame.EnvironmentData.isTablet)
        {
            //_cameraScaler.
        }
    }
}
