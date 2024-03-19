using DG.Tweening;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Sequence sequence;
    private RectTransform _rectTransform;
    [SerializeField] private float _distanceToMoove;
    [SerializeField] private float _animationDuration;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        sequence = DOTween.Sequence();


        sequence.Append(_rectTransform.DOAnchorPosY( _distanceToMoove, _animationDuration, false).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear));


    }
}
