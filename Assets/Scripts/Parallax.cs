using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private ParallaxLayer layer1Prefab, layer2Prefab, layer3Prefab;

    private List<ParallaxLayer> layers1 = new List<ParallaxLayer>();
    private List<ParallaxLayer> layers2 = new List<ParallaxLayer>();
    private List<ParallaxLayer> layers3 = new List<ParallaxLayer>();

    [SerializeField]
    private List<GenBlock> blocks;

    [SerializeField]
    private Vector3 spawnPositionOffset;

    private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        foreach (ParallaxLayer layer in layers1)
        {
            MoveLayer(layer);
        }

        foreach (ParallaxLayer layer in layers2)
        {
            MoveLayer(layer);
        }

        foreach (ParallaxLayer layer in layers3)
        {
            MoveLayer(layer);
        }
    }

    private void MoveLayer(ParallaxLayer layer)
    {
        float temp = (cam.transform.position.x * (1 - layer.Speed));
        float distance = cam.transform.position.x * layer.Speed;

        layer.transform.position = new Vector3(layer.StartPosition - distance, layer.transform.position.y, layer.transform.position.z);

        if (temp > layer.StartPosition + layer.Lenght)
        {
            layer.StartPosition += layer.Lenght;
        }
        else if (temp < layer.StartPosition - layer.Lenght)
        {
            layer.StartPosition -= layer.Lenght;
        }
    }

    private void SpawnBlock(ParallaxLayer layerPrefab, List<ParallaxLayer> layerList, Vector3 position)
    {
        ParallaxLayer layer = Instantiate(layerPrefab, transform);
        layer.transform.position = position + spawnPositionOffset;
        layer.LoadBlock(GetBlock());
        layerList.Add(layer);

        DeleteOldBlock(layerList);
    }


    private GenBlock GetBlock()
    {
        int rand = Random.Range(0, blocks.Count);
        return blocks[rand];
    }

    public void AddBlocks(Vector3 position)
    {
        SpawnBlock(layer1Prefab, layers1, position);
        SpawnBlock(layer2Prefab, layers2, position);
        SpawnBlock(layer3Prefab, layers3, position);
    }

    public void DeleteOldBlock(List<ParallaxLayer> layerList)
    {
        if (layerList.Count > 3)
        {
            Destroy(layerList[0].gameObject);
            layerList.RemoveAt(0);
        }
    }
}
