using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
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
