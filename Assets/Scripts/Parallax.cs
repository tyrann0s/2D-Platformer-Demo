using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPosition;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float speed;

    private void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<Tilemap>().localBounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - speed));
        float distance = cam.transform.position.x * speed;

        transform.position = new Vector3(startPosition - distance, transform.position.y, transform.position.z);

        if (temp > startPosition + lenght)
        {
            startPosition += lenght;
        }
        else if (temp < startPosition - lenght)
        {
            startPosition -= lenght;
        }
    }
}
