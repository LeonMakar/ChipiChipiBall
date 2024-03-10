using System.Collections.Generic;
using UnityEngine;

public class CustomePool<T> where T : MonoBehaviour
{
    private Stack<T> _nonActiveObjectsStack;
    private Stack<T> _activeObjectsStack;
    private IFactory _factory;
    private T _selectedGameObject;



    public void InitializePool(IFactory factory, int initObjectsCount)
    {
        _factory = factory;
        _activeObjectsStack = new Stack<T>();
        _nonActiveObjectsStack = new Stack<T>();
        for (int i = 0; i < initObjectsCount; i++)
        {
            var prefabGameObject = _factory.Create();
            prefabGameObject.SetActive(false);
            _nonActiveObjectsStack.Push(prefabGameObject.GetComponent<T>());
        }
    }
    public void RemooveAllObject()
    {
        for (int i = 0; i < _activeObjectsStack.Count; i++)
        {
            _selectedGameObject = _activeObjectsStack.Pop();
            DropBackToPool( _selectedGameObject );
        }
    }

    public T GetFromPool()
    {

        if (_nonActiveObjectsStack.Count > 0)
        {
            _selectedGameObject = _nonActiveObjectsStack.Pop();
            _activeObjectsStack.Push(_selectedGameObject);
        }
        else
        {
            _selectedGameObject = CreateGameObjectForPool();
            _activeObjectsStack.Push(_selectedGameObject);
        }
        _selectedGameObject.gameObject.SetActive(true);
        return _selectedGameObject;
    }

    public void DropBackToPool(T gameObject)
    {
        gameObject.gameObject.SetActive(false);
        _nonActiveObjectsStack.Push(gameObject);
    }

    private T CreateGameObjectForPool()
    {

        var prefabGameObject = _factory.Create();
        return prefabGameObject.GetComponent<T>();

    }
}
