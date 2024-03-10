using UnityEngine;
using Zenject;

public class BallFactory : IFactory
{
    private DiContainer _container;
    public GameObject _ballPrefab;

    public BallFactory(DiContainer diContainer)
    {
        _container = diContainer;
    }
    public void LoadFactoryResources(GameObject prefab) => _ballPrefab = prefab;
    public GameObject Create()
    {
       return  _container.InstantiatePrefab(_ballPrefab);
    }
}