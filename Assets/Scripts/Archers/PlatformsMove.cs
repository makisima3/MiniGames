using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, 2);

        if (rnd == 0)
        {
            StartCoroutine(MoveUp());
        }
        else
        {
            StartCoroutine(MoveDown());
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MoveDown()
    {
        while (transform.position.y > -3)
        {
            int rnd = Random.Range(0, 11);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.08f);
            if (rnd != 10)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }


        StartCoroutine(MoveUp());

    }

    IEnumerator MoveUp()
    {
        while (transform.position.y < 1.5f)
        {
            int rnd = Random.Range(0, 11);
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.08f);
            if(rnd != 10)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
            
        }

        StartCoroutine(MoveDown());
    }
}
