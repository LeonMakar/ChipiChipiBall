using UnityEngine;
using Zenject;

public class SimpleBall : MonoBehaviour, IBall
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;


    private PaddleMooving _paddleMooving;

    private Vector2 _direction;

    [Inject]
    public void Construct(PaddleMooving paddlemooving)
    {
        _paddleMooving = paddlemooving;
    }

    private void Start()
    {
        _rigidbody.AddForce(Vector3.up * _ballSpeed, ForceMode2D.Impulse);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == GlobalVariables.PLATFORM_CENTER_TAG)
        {
            _rigidbody.velocity = Vector2.up * _ballSpeed;
            Debug.Log("ÓÄÀð Öåíòð");
        }
        else if (collision.collider.tag == GlobalVariables.PLATFORM_RIGHT_TAG)
        {
            _rigidbody.AddForce(Vector2.right * 8, ForceMode2D.Impulse);
            _rigidbody.velocity = _rigidbody.velocity.normalized * _ballSpeed;
            Debug.Log("ÓÄÀð Ïðàâî");

        }
        else if (collision.collider.tag == GlobalVariables.PLATFORM_LEFT_TAG)
        {
            _rigidbody.AddForce(Vector2.left * 8, ForceMode2D.Impulse);
            _rigidbody.velocity = _rigidbody.velocity.normalized * _ballSpeed;
            Debug.Log("ÓÄÀð Ëåâî");

        }
        else
        {
            switch (Random.Range(0, 1))
            {
                case 0:
                    _rigidbody.AddForce(Vector2.left, ForceMode2D.Impulse);
                    break;
                case 1:
                    _rigidbody.AddForce(Vector2.right, ForceMode2D.Impulse);
                    break;
            }

        }
    }

    public class Factory : PlaceholderFactory<SimpleBall> { }
}


public interface IBall
{

}
