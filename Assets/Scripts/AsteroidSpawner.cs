using System.Collections; // Required for IEnumerator
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 1.0f;
    public float spawnDistance = 10.0f;
    public int spawnAmount = 1;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true) // Continuously spawn asteroids
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle.normalized * spawnDistance;
                Vector3 spawnPoint = transform.position + spawnPosition; // Corrected variable name

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
                asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
                asteroid.SetTrajectory(rotation * -spawnPosition); // Corrected variable name
            }
            yield return new WaitForSeconds(1.0f / spawnRate);
        }
    }
}
