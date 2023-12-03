using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : Threat
{
    [SerializeField]
    private GameObject startPoint, endPoint;

    [SerializeField]
    private float movingSpeed, startDelay, delay;

    [SerializeField]
    private DamageCollider damageCollider;

    private void Start()
    {
        damageCollider.transform.position = startPoint.transform.position;
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(DelayTime(startDelay));

            IsWorking = true;
            while (damageCollider.transform.position != endPoint.transform.position)
            {
                damageCollider.transform.position = Vector3.Lerp(damageCollider.transform.position, endPoint.transform.position, movingSpeed);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(.2f);

            IsWorking = false;
            while (damageCollider.transform.position != startPoint.transform.position)
            {
                damageCollider.transform.position = Vector3.Lerp(damageCollider.transform.position, startPoint.transform.position, movingSpeed / 10);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(DelayTime(delay));
        }
    }

    private float DelayTime(float _delay)
    {
        if (_delay > 0) return _delay / (threatsManager.Speed / 2); else return 0;
    }
}
