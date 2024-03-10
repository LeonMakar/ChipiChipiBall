using UnityEngine;
using Zenject;

public class BonusFactory<T> : IFactory where T : Bonus
{
    private GameObject _prefab;
    private DiContainer _container;
    public BonusFactory(DiContainer diContainer)
    {
        _container = diContainer;
    }
    public GameObject Create()
    {
        return _container.InstantiatePrefab(_prefab);
    }

    public void LoadFactoryResources(GameObject prefab)
    {
        _prefab = prefab;
    }

}
