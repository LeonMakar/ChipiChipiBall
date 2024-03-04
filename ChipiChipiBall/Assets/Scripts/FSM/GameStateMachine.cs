using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{

    private SimpleBall.Factory _ballFactory;
    private PaddleMooving _paddle;

    [Inject]
    public void Construct(SimpleBall.Factory ballFactory, PaddleMooving paddleMooving)
    {
        _ballFactory = ballFactory;
        _paddle = paddleMooving;
    }

    public void StartGame()
    {
        _ballFactory.Create().transform.position = _paddle.transform.position + Vector3.up;
    }
}
