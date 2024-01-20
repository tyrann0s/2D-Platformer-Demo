using UnityEngine;

public class StartingBlock : Block
{
    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
