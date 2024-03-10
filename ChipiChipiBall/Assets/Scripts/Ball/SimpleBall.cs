using UnityEngine;
using Zenject;

public class SimpleBall : MonoBehaviour, IBall
{
    [SerializeField] private float _ballSpeed;
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }


    private PaddleMooving _paddleMooving;


    [Inject]
    public void Construct(PaddleMooving paddlemooving)
    {
        _paddleMooving = paddlemooving;
    }

    private void OnEnable()
    {
        Rigidbody.AddForce(Vector3.up * _ballSpeed, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == GlobalVariables.PLATFORM_TAG)
        {
            Vector3 paddleCenter = _paddleMooving.transform.position;
            Vector3 hitPoint = collision.contacts[0].point;

            float diviation = hitPoint.x - paddleCenter.x;

            Rigidbody.AddForce(new Vector2(diviation, 0) * 5, ForceMode2D.Impulse);
            Rigidbody.velocity = Rigidbody.velocity.normalized * _ballSpeed;
        }
        else
            Rigidbody.velocity = Rigidbody.velocity.normalized * _ballSpeed;
    }
}


public interface IBall
{

}
