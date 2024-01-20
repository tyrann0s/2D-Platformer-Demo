using System.Collections;
using UnityEngine;

public class Press : Threat
{
    [SerializeField]
    private GameObject startPoint, endPoint;

    [SerializeField]
    private float movingSpeed, startDelay, delay;

    [SerializeField]
    private DamageCollider damageCollider;

    [SerializeField]
    private AudioSource pressSound;

    private void Start()
    {
        damageCollider.transform.position = startPoint.transform.position;
        pressSound.pitch += Random.value;
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(DelayTime(startDelay));

            IsWorking = true;

            pressSound.Play();
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
