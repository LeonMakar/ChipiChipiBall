using UnityEngine;

public interface IFactory
{
    GameObject Create();
    void LoadFactoryResources(GameObject prefab);
}