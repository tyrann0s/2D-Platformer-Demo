using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float smoothing;

    [SerializeField]
    private float verticalOffset;

    private Player player;

    public void SetUpCamera(Player playerRef)
    {
        player = playerRef;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + verticalOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, smoothing * Time.fixedDeltaTime);
        }
    }
}
