using UnityEngine;

public interface IMonoBehaviorFactory
{
    public T Create<T>() where T : MonoBehaviour;
}
