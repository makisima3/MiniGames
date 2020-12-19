using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public static TrapSpawner Instance { get; private set; }

    public GameObject CurrentTrup { get; private set; }

    public float maxDelay = 3f, minDelay = 1f;

    public GameObject trapPrefab;

    public List<GameObject> points;

    public bool isGame = true;

    public Coroutine trapSpawnDelay;

    private bool isOnStart = true;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        trapSpawnDelay = StartCoroutine(TrapSpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TrapSpawn()
    {
        trapSpawnDelay = StartCoroutine(TrapSpawnDelay());
    }

    IEnumerator TrapSpawnDelay()
    {
        if (isOnStart)
            yield return new WaitForSeconds(5);
        else
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        CurrentTrup = Instantiate(trapPrefab, transform);
        CurrentTrup.transform.position = points[Random.Range(0, points.Count)].transform.position;
    }

    public void GameOver()
    {
        //Destroy(GetComponent<TrapSpawner>());
        Debug.Log("GameOver");
    }
}
