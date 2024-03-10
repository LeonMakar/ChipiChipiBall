using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class BallsController
{
    private CustomePool<SimpleBall> _ballPool;
    public List<SimpleBall> Balls = new List<SimpleBall>();
    private List<SimpleBall> _temporaryBalls = new List<SimpleBall>();

    public static int BallsCount;

    public BallsController(CustomePool<SimpleBall> ballPool)
    {
        _ballPool = ballPool;
    }

    public void AddBallToList(SimpleBall ball)
    {
        Balls.Add(ball);
        BallsCount++;
    }

    public async UniTaskVoid MultiPlyBy3AllBallsAsync()
    {
        foreach (SimpleBall ball in Balls)
        {
            await MultiBallsAsync(ball);
        }
        foreach (SimpleBall ball in _temporaryBalls)
            AddBallToList(ball);
    }

    private async UniTask MultiBallsAsync(SimpleBall ball)
    {
        for (int i = 0; i < 3; i++)
        {
            var newBall = _ballPool.GetFromPool();
            newBall.transform.position = ball.transform.position;
            newBall.Rigidbody.velocity = ball.Rigidbody.velocity;
            switch (Random.Range(0, 1))
            {
                case 0:
                    newBall.Rigidbody.AddForce(newBall.transform.TransformVector(Vector2.left) * 10, ForceMode2D.Impulse);
                    break;
                case 1:
                    newBall.Rigidbody.AddForce(newBall.transform.TransformVector(Vector2.left) * 10, ForceMode2D.Impulse);
                    break;
            }
            _temporaryBalls.Add(newBall);
        }
        await UniTask.Yield();

    }

}
