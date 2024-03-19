using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class BallsController
{
    private CustomePool<SimpleBall> _ballPool;
    private GameToken _gameToken;
    private EventBus _eventBus;
    public List<SimpleBall> Balls = new List<SimpleBall>();
    private List<SimpleBall> _temporaryBalls = new List<SimpleBall>();
    private Stack<int> _calls = new Stack<int>();
    private CustomeStackOfActions _stackActions;

    public static int BALLS_COUNT;

    public BallsController(CustomePool<SimpleBall> ballPool, GameToken gameToken, EventBus eventBus)
    {
        _ballPool = ballPool;
        _gameToken = gameToken;
        _eventBus = eventBus;

        _eventBus.OnGameWin += RemoveAllBlocks;
        _eventBus.OnGameLoose += RemoveAllBlocks;

        _stackActions = new CustomeStackOfActions(gameToken, this);

    }
    private void RemoveAllBlocks()
    {
        foreach (SimpleBall ball in Balls)
        {
            ball.CanMylty = false;
            ball.gameObject.SetActive(false);
        }
        foreach (SimpleBall ball in _temporaryBalls)
        {
            ball.CanMylty = false;
            ball.gameObject.SetActive(false);
        }
    }
    public void RemoveBall()
    {
        BALLS_COUNT--;
        if (BALLS_COUNT == 0)
        {
            Debug.Log("GameOver");
        }
    }
    public void AddBallToList(SimpleBall ball)
    {
        BALLS_COUNT++;
        Balls.Add(ball);
    }
    public void RemoveBallToList(SimpleBall ball)
    {
        Balls.Remove(ball);
        BALLS_COUNT--;
    }

    public void MultiPlyBy3AllBallsAsync()
    {
        _stackActions.AddToStackAction(0);
    }

    public async UniTask MultiThenAddBallToListAsync()
    {
        foreach (SimpleBall ball in Balls)
        {
            if (ball.CanMylty)
                await MultiBallsAsync(ball);
        }
        foreach (SimpleBall ball in _temporaryBalls)
            AddBallToList(ball);
        _temporaryBalls.Clear();
        await UniTask.Yield();
    }

    private async UniTask MultiBallsAsync(SimpleBall ball)
    {
        for (int i = 0; i < 2; i++)
        {
            var newBall = _ballPool.GetFromPool();
            newBall.transform.position = ball.transform.position;
            newBall.Rigidbody.velocity = ball.Rigidbody.velocity;
            if (i == 0)
                newBall.Rigidbody.AddForce(newBall.transform.TransformVector(Vector2.left) * 10, ForceMode2D.Impulse);
            else
                newBall.Rigidbody.AddForce(newBall.transform.TransformVector(Vector2.right) * 10, ForceMode2D.Impulse);
            _temporaryBalls.Add(newBall);
            await UniTask.Yield(_gameToken.destroyCancellationToken);
        }

    }

}

public class CustomeStackOfActions
{
    private readonly GameToken gameToken;
    private readonly BallsController _ballsController;
    private Stack<int> _stack = new Stack<int>();

    public CustomeStackOfActions(GameToken gameToken, BallsController ballsController)
    {
        this.gameToken = gameToken;
        _ballsController = ballsController;
        CheckActionsToDoAsync().Forget();
    }

    public void AddToStackAction(int v)
    {
        _stack.Push(v);
    }


    private async UniTaskVoid CheckActionsToDoAsync()
    {
        while (!gameToken.destroyCancellationToken.IsCancellationRequested)
        {
            if (_stack.Count > 0 && BallsController.BALLS_COUNT < 500)
            {
                var method = _stack.Pop();
                await _ballsController.MultiThenAddBallToListAsync();
            }
            await UniTask.Delay(300, false, PlayerLoopTiming.Update, gameToken.destroyCancellationToken);
        }
    }



}
