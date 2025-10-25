using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float posMin, posMax;

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    IEnumerator SpawnPipe()
    {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(pipe, transform.position + Vector3.up * Random.Range(posMin, posMax),  Quaternion.identity);
            StartCoroutine(SpawnPipe());
    }
}
