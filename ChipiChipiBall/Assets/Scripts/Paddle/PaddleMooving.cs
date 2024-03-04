using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PaddleMooving : MonoBehaviour
{
    [SerializeField] private float _paddleSpeed;
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
        PaddleDirectionMoovement = new Vector2(context.ReadValue<float>()*20, 0);
    }

    private IEnumerator PaddleMoovement(InputAction.CallbackContext context)
    {
        while (_inputMap.Simple.Mooving.IsPressed())
        {
            transform.Translate(Vector2.up * context.ReadValue<float>() * -_paddleSpeed * Time.deltaTime);

            yield return null;
        }
        PaddleDirectionMoovement = Vector2.zero;
    }

    public class Factory : PlaceholderFactory<PaddleMooving> { }
}
