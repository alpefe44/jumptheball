using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject enemyPrefab;
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

        GameObject circle = Instantiate(circlePrefab, spawnPos, Quaternion.identity);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos - new Vector2(spawnPos.x, -2f), Quaternion.identity);
        float randomScaleValue = Random.Range(0.1f, 1f);
        circle.transform.localScale = new Vector3(randomScaleValue, randomScaleValue, randomScaleValue);

        lastSpawnPosition = spawnPos;
    }

}
