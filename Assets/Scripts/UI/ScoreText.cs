using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition;
    private bool isReadyForLaunch = false;

    public void Init(GameObject _target, Vector3 _upPos)
    {
        target = _target;
        DOTween.Sequence(transform.DOMove(_upPos, 1f)).
            AppendInterval(.5f).
            SetEase(Ease.OutSine).
            OnComplete(Launch);
    }

    private void Launch()
    {
        isReadyForLaunch = true;
        StartCoroutine(DeathTimer());
    }

    private void LateUpdate()
    {
        if (isReadyForLaunch)
        {
            Vector3 screenSpacePos = Camera.main.ScreenToWorldPoint(target.transform.position);
            targetPosition = new Vector3(screenSpacePos.x, screenSpacePos.y);
            transform.DOMove(targetPosition, 1f);
        }
    }

    //private void UpdateScore()
    //{
    //    FindObjectOfType<UIManager>().SetScoreText();
    //}

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<UIManager>().SetScoreText();
        Destroy(gameObject);
    }
}
