using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    private CustomePool<SimpleBall> _ballPool;
    private PaddleMooving _paddle;
    private BallsController _ballsController;
    private EventBus _eventBus;
    private GameFinishSelector _gameFinishSelector;
    private GameToken _token;
    [SerializeField] private int _blockCount;
    [SerializeField] private TextMeshProUGUI _blockCountText;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _gameLoosePanel;
    [SerializeField] private Transform _videoTransform;
    [SerializeField] private GameObject[] _nextActionButtones;
    [SerializeField] private GameObject[] _loadingButtones;



    [ContextMenu("CountBalls")]
    public void CountAllBallsAmmount()
    {
        var count = FindObjectsByType<Block>(FindObjectsSortMode.None);
        _blockCount = count.Length;
        Debug.Log("Всего блоков= " + _blockCount);
        _blockCountText.text = _blockCount.ToString();
    }
    private void Start()
    {
        StartGame();
    }
    public void RemoveBall()
    {
        _blockCount--;
        _blockCountText.text = _blockCount.ToString();

        if (_blockCount == 0)
        {
            BallsController.BALLS_COUNT = 0;
            Destroy(_token);
            _videoTransform.localScale += Vector3.one * 25;
            _videoTransform.position = _videoTransform.position + Vector3.left;
            WaitBeforeDoSomethingAsync().Forget();
            _eventBus.OnGameWin.Invoke();
            _gameFinishSelector.SetGameFinishState(true);
        }
    }
    [Inject]
    public void Construct(CustomePool<SimpleBall> ball, PaddleMooving paddleMooving, BallsController ballsController, EventBus eventBus,
        GameFinishSelector gameFinishSelector, GameToken token)
    {
        _ballPool = ball;
        _paddle = paddleMooving;
        _ballsController = ballsController;
        _eventBus = eventBus;
        _gameFinishSelector = gameFinishSelector;
        _token = token;
    }

    public async UniTaskVoid WaitBeforeDoSomethingAsync()
    {
        await UniTask.Delay(1500, true, PlayerLoopTiming.Update, gameObject.GetCancellationTokenOnDestroy());
        YandexGame.FullscreenShow();
        await UniTask.Delay(500, true, PlayerLoopTiming.Update, gameObject.GetCancellationTokenOnDestroy());
        foreach (var item in _loadingButtones)
            item.SetActive(false);
        foreach (var item in _nextActionButtones)
            item.SetActive(true);


    }

    public void StartGame()
    {
        var ball = _ballPool.GetFromPool();
        ball.transform.position = _paddle.transform.position + Vector3.up;
        _ballsController.AddBallToList(ball);
    }
}
