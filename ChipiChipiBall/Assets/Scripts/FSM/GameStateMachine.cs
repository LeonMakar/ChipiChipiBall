using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    private CustomePool<SimpleBall> _ballPool;
    private PaddleMooving _paddle;
    private BallsController _ballsController;

    [Inject]
    public void Construct(CustomePool<SimpleBall> ball, PaddleMooving paddleMooving, BallsController ballsController)
    {
        _ballPool = ball;
        _paddle = paddleMooving;
        _ballsController = ballsController;
    }

    public void StartGame()
    {
        var ball = _ballPool.GetFromPool();
        ball.transform.position = _paddle.transform.position + Vector3.up;
        _ballsController.AddBallToList(ball);
    }
}
