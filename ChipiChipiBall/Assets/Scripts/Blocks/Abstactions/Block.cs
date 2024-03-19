using UnityEngine;
using Zenject;

public abstract class Block : MonoBehaviour
{

    [SerializeField] private int _lifes;
    private MediaMaterialController _mediaController;
    private CustomePool<X3Bonus> _x3Pool;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(CustomePool<X3Bonus> customePoolX3, GameStateMachine gameStateMachine)
    {
        _x3Pool = customePoolX3;
        _gameStateMachine = gameStateMachine;
    }
    public void Start()
    {
        _mediaController = GlobalVariables.MEDIA;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _mediaController.CanPlayPositiveClip = true;
        _mediaController.ChangeClip();
        _lifes--;
        if (_lifes == 0)
        {
            DestroyBlock();
            _gameStateMachine.RemoveBall();
        }
    }
    private void DestroyBlock()
    {
        if (BallsController.BALLS_COUNT < 350)
        {
            switch (Random.Range(0, 100))
            {
                case int n when (n <= 5):
                    var bonus = _x3Pool.GetFromPool();
                    bonus.transform.position = transform.position;
                    break;
            }
        }
        gameObject.SetActive(false);
    }
}
