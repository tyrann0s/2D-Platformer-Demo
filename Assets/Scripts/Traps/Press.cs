using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : Threat
{
    [SerializeField]
    private GameObject startPoint, endPoint;

    [SerializeField]
    private float speed, startDelay, delay;

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
            yield return new WaitForSeconds(startDelay);

            IsWorking = true;
            while (damageCollider.transform.position != endPoint.transform.position)
            {
                damageCollider.transform.position = Vector3.Lerp(damageCollider.transform.position, endPoint.transform.position, speed);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(.2f);

            IsWorking = false;
            while (damageCollider.transform.position != startPoint.transform.position)
            {
                damageCollider.transform.position = Vector3.Lerp(damageCollider.transform.position, startPoint.transform.position, speed / 10);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
