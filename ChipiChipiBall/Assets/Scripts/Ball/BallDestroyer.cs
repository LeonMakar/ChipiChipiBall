using UnityEngine;
using YG;
using Zenject;

public class BallDestroyer : MonoBehaviour
{
    private BallsController _ballsController;
    private EventBus _eventBus;
    private GameFinishSelector _gameFinishSelector;
    private GameStateMachine _gameMachine;

    [Inject]
    public void Construct(BallsController ballsController, EventBus eventBus, GameFinishSelector gameFinishSelector, GameStateMachine gameStateMachine)
    {
        _ballsController = ballsController;
        _eventBus = eventBus;
        _gameFinishSelector = gameFinishSelector;
        _gameMachine = gameStateMachine;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GlobalVariables.DEFAULT_TAG)
        {
            BallsController.BALLS_COUNT--;
            if (BallsController.BALLS_COUNT <= 0)
            {
                BallsController.BALLS_COUNT = 0;
                _eventBus.OnGameLoose();
                _gameMachine.WaitBeforeDoSomethingAsync().Forget();
                _gameFinishSelector.SetGameFinishState(false);
            }
            collision.gameObject.GetComponent<SimpleBall>().CanMylty = false;
            collision.gameObject.SetActive(false);
        }
    }
}
