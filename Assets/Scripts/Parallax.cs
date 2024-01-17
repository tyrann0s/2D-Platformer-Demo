using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private ParallaxLayer layer1Prefab, layer2Prefab, layer3Prefab;
    
    private List<ParallaxLayer> layers1 = new List<ParallaxLayer>();
    private List<ParallaxLayer> layers2 = new List<ParallaxLayer>();
    private List<ParallaxLayer> layers3 = new List<ParallaxLayer>();

    [SerializeField]
    private List<GenBlock> blocks;

    private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        AddBlocks();
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

    private void SpawnBlock(ParallaxLayer layerPrefab, List<ParallaxLayer> layerList)
    {
        ParallaxLayer layer = Instantiate(layerPrefab, transform);
        layer.transform.position = layerList.Count > 0 ? layerList[layerList.Count-1].SpawnPosition : layer.transform.position;
        layer.LoadBlock(GetBlock());
        layerList.Add(layer);

        DeleteOldBlock(layerList);
    }


    private GenBlock GetBlock()
    {
        int rand = Random.Range(0, blocks.Count);
        return blocks[rand];
    }

    public void AddBlocks()
    {
        SpawnBlock(layer1Prefab, layers1);
        SpawnBlock(layer2Prefab, layers2);
        SpawnBlock(layer3Prefab, layers3);

        SpawnBlock(layer1Prefab, layers1);
        SpawnBlock(layer2Prefab, layers2);
        SpawnBlock(layer3Prefab, layers3);
    }

    public void DeleteOldBlock(List<ParallaxLayer> layerList)
    {
        if (layerList.Count > 3)
        {
            Destroy(layerList[0]);
            layerList.RemoveAt(0);
        }
    }
}
