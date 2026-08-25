using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 2f;
    public float upperLimit = 1.5f;
    public float lowerLimit = -1.5f;

    private void OnEnable()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnObject");
    }

    private void SpawnObject()
    {
        GameObject pipes = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(lowerLimit, upperLimit);
    }
}