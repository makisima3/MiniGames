using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrapSpawner : MonoBehaviour
{
    public static TrapSpawner Instance { get; private set; }

    public GameObject CurrentTrup { get; private set; }

    public float maxDelay = 3f, minDelay = 1f;

    public GameObject trapPrefab;

    public List<GameObject> points;

    public bool isGame = true;

    public Coroutine trapSpawnDelay;

    public Text endPanelText;
    public GameObject EndPanel;

    public GameObject bgMover;

    public ParticleSystem particleSystem1, particleSystem2;

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

        Time.timeScale = 0;

        Destroy(bgMover.GetComponent<BgMover>());

        endPanelText.text = TrupTrigger.name + "the Winner";
        particleSystem1.gameObject.SetActive(true);
        particleSystem2.gameObject.SetActive(true);
        EndPanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
