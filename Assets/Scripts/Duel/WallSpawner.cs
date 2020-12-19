using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public static WallSpawner Instance { get; private set; }

    public GameObject currenWall { get; private set; }

    public List<Transform> points;

    public GameObject wallPrefab;

    public float respawnDelay = 1;

    private Coroutine spawn;

    private void Awake()
    {
        Instance = this;

        spawn = StartCoroutine(Spawn());
    }

    public void SpawnWall()
    {
        spawn = StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        currenWall = Instantiate(wallPrefab, transform);
        currenWall.transform.position = points[Random.Range(0,points.Count)].position;
    }
}
