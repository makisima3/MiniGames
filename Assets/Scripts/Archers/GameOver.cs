using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    [SerializeField] private Text victiryText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameOverDelay(string player)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Arrow"))
        {
            Destroy(item);
        } 

        victiryText.text = player + " Win";
        victiryText.gameObject.SetActive(true);

        for (float i = 1; i >= -0f; i -= 0.1f)
        {
            Time.timeScale = i;

            Debug.Log(Time.timeScale);
            yield return new WaitForSeconds(0.1f);

            if (Time.timeScale < 0.1f)
            {
                Time.timeScale = 0;
            }
        }
    }
}
