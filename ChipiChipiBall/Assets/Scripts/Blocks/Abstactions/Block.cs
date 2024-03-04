using UnityEngine;
using Zenject;

public abstract class Block : MonoBehaviour
{

    [SerializeField] private int _lifes;
    private MediaMaterialController _mediaController;

   
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
        Destroy(gameObject);
    }
}
