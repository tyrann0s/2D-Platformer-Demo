using System.Collections;
using UnityEngine;

public class EnemyMover : Threat
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject startPos, endPos;

    [SerializeField]
    private Enemy enemy;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        for (; ; )
        {
            while (enemy.transform.position != endPos.transform.position)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, endPos.transform.position, SpeedNormalize());
                yield return new WaitForEndOfFrame();
            }

            while (enemy.transform.position != startPos.transform.position)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos.transform.position, SpeedNormalize());
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private float SpeedNormalize() { return (speed * threatsManager.Speed) / 1000; }
}
