using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    bool IsFinished = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!IsFinished)
            {
                StartCoroutine(PlayerFinish());
                IsFinished = true;
            }

        }
    }

    IEnumerator PlayerFinish()
    {
        for (float i = 1; i > 0; i -= 0.1f)
        {
            Time.timeScale = i;
            yield return new WaitForSeconds(0.1f);
        }

        Time.timeScale = 0;
    }

}
