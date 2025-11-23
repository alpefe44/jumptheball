using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject circlePrefab;
    public Transform player;

    public float spawnDistance = 3f;
    public float xRange = 2f;

    private Vector2 lastSpawnPosition;

    private void Start()
    {
        lastSpawnPosition = player.position;
        for (int i = 0; i < 5; i++)
        {
            SpawnCircle();
        }
    }

    private void Update()
    {
        if (Vector2.Distance(player.position, lastSpawnPosition) < 10f)
        {
            SpawnCircle();
        }
    }

    void SpawnCircle()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-xRange, xRange), lastSpawnPosition.y + spawnDistance);

        Instantiate(circlePrefab, spawnPos, Quaternion.identity);

        lastSpawnPosition = spawnPos;
    }
}
