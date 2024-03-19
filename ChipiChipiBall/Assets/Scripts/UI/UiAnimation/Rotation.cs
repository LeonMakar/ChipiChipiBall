using DG.Tweening;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;

    void Start()
    {

        _transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);



        //transform.DORotate(Vector3.left, 3, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
    }


}
