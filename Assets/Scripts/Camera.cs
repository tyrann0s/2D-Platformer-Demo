using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float smoothing;

    [SerializeField]
    private float verticalOffset;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + verticalOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPos, smoothing * Time.fixedDeltaTime);
    }
}
