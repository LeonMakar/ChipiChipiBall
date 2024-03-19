using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PaddleMooving : MonoBehaviour
{
    [SerializeField] private float _paddleSpeed;
    [SerializeField] private Rigidbody2D _rigidBody;
    public Vector2 PaddleDirectionMoovement { get; private set; }


    private DefaultActionMap _inputMap;


    [Inject]
    public void Construct(DefaultActionMap map)
    {
        _inputMap = map;
        _inputMap.Simple.Mooving.performed += StartMoovement;
    }

    private void StartMoovement(InputAction.CallbackContext context)
    {
        StartCoroutine(PaddleMoovement(context));
        //PaddleDirectionMoovement = new Vector2(context.ReadValue<float>()*20, 0);
    }
    private void Update()
    {
        //_rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        if (_inputMap.Simple.Mooving.IsPressed())
        {
            _rigidBody.velocity = Vector2.left * _inputMap.Simple.Mooving.ReadValue<float>() * -_paddleSpeed;
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }
    private IEnumerator PaddleMoovement(InputAction.CallbackContext context)
    {
        while (_inputMap.Simple.Mooving.IsPressed())
        {
            //transform.Translate(Vector2.up * context.ReadValue<float>() * -_paddleSpeed * Time.deltaTime);

            yield return null;
        }
        _rigidBody.velocity = Vector2.zero;
        //PaddleDirectionMoovement = Vector2.zero;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    public class Factory : PlaceholderFactory<PaddleMooving> { }
}
