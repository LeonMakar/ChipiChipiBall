using UnityEngine;
using Zenject;

public abstract class Block : MonoBehaviour
{

    [SerializeField] private int _lifes;
    private MediaMaterialController _mediaController;
    private CustomePool<X3Bonus> _x3Pool;

    [Inject]
    private void Construct(CustomePool<X3Bonus> customePoolX3)
    {
        _x3Pool = customePoolX3;
    }
    public void Start()
    {
        _mediaController = GlobalVariables.MEDIA;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _mediaController.CanPlayPositiveClip = true;
        _mediaController.ChangeClipAsync().Forget();
        _lifes--;
        if (_lifes == 0)
        {
            DestroyBlock();
        }
    }
    private void DestroyBlock()
    {
        switch (Random.Range(0, 100))
        {
            case int n when (n <= 10):
                if (BallsController.BallsCount <= 150)
                {
                    var bonus = _x3Pool.GetFromPool();
                    bonus.transform.position = transform.position;
                }
                break;
        }
        Destroy(gameObject);
    }
}
