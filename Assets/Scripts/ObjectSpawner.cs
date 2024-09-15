using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab; // The point (cube) object
    [SerializeField] private GameObject obstaclePrefab; // The obstacle object
    [SerializeField] private Transform center; // The center around which objects spawn
    [SerializeField] private float spawnRadius = 5f; // Radius around which points spawn

    [SerializeField] private float spawnInterval = 2f; // Interval between spawning points/obstacles
    [SerializeField] private int maxObstacles = 3; // Maximum number of obstacles allowed
    private List<GameObject> activeObstacles = new List<GameObject>();

    void Start()
    {
        // Start spawning points and obstacles at intervals
        InvokeRepeating("SpawnPoint", 1f, spawnInterval);
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnPoint()
    {
        // Random point on the cat's orbit for the points
        Vector2 spawnPosition = RandomPointOnOrbit(center.position, spawnRadius);
        Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnObstacle()
    {
        // Check if there are too many obstacles on the screen
        if (activeObstacles.Count >= maxObstacles)
        {
            return;
        }

        // Random position for obstacle, starting on the left side
        Vector2 spawnPosition = new Vector2(-8f, Random.Range(-3f, 3f)); // Left side spawn position
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        activeObstacles.Add(newObstacle); // Keep track of active obstacles
    }

    void Update()
    {
        // Clean up obstacles that have been destroyed or moved off-screen
        activeObstacles.RemoveAll(obstacle => obstacle == null || IsOffScreen(obstacle));
    }

    Vector2 RandomPointOnOrbit(Vector2 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        return center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }

    bool IsOffScreen(GameObject obj)
    {
        // Check if the object is off the screen (can adjust the boundary values)
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(obj.transform.position);
        return screenPoint.x < 0 || screenPoint.x > 1;
    }
}
