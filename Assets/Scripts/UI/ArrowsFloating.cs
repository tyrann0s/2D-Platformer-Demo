using DG.Tweening;
using UnityEngine;

public class ArrowsFloating : MonoBehaviour
{
    [SerializeField]
    private float endValue, force;

    void Start()
    {
        transform.DOMoveY(transform.position.y - endValue, force).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo);
    }
}
