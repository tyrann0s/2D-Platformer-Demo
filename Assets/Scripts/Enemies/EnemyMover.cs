using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private GameObject startPos, endPos;

    [SerializeField]
    private float speed;

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
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, endPos.transform.position, Speed());
                yield return new WaitForEndOfFrame();
            }

            while (enemy.transform.position != startPos.transform.position)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos.transform.position, Speed());
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private float Speed() { return speed / 1000; }
}
