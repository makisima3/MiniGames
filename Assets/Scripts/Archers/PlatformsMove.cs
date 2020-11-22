using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, 2);

        if(rnd == 0)
        {
            StartCoroutine(MoveUp());
        }
        else
        {
            StartCoroutine(MoveDown());
        }
    }

    IEnumerator MoveDown()
    {
        while(transform.position.y > -3)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
            yield return new WaitForSeconds(0.6f);
        }

        StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        while (transform.position.y < 1.5f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(MoveDown());
    }
}
