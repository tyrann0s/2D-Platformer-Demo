using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatsManager : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float Speed => speed;

    [SerializeField]
    private float speedMod;

    public void IncreaseSpeed()
    {
        speed += speedMod;
    }
}
