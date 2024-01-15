using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private GameObject shootingPoint;

    [SerializeField]
    private float shootingDelay;

    [SerializeField]
    private bool isFacingLeft;

    [SerializeField]
    private AudioSource shootSound;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        for (; ;)
        {
            GameObject projGO = Instantiate(projectilePrefab);
            projGO.transform.position = shootingPoint.transform.position;
            Projectile projectile = projGO.GetComponent<Projectile>();
            projectile.Init(isFacingLeft, threatsManager.Speed);
            shootSound.Play();

            yield return new WaitForSeconds(shootingDelay / (threatsManager.Speed / 2));
        }
    }
}
