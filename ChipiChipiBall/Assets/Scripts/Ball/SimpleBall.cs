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
        if (collision.collider.tag == GlobalVariables.PLATFORM_TAG)
        {
            _rigidbody.AddForce(_paddleMooving.PaddleDirectionMoovement, ForceMode2D.Impulse);
            _rigidbody.velocity = _rigidbody.velocity.normalized * _ballSpeed;
        }
    }

    public class Factory : PlaceholderFactory<SimpleBall> { }
}


public interface IBall
{

}
