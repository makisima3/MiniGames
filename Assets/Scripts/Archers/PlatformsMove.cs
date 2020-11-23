using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlatformsMove : MonoBehaviour
{
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, 2);

        Move(rnd);
        //if (rnd == 0)
        //{
        //    Moveup(1);
        //}
        //else
        //{
        //    Movedown(1);
        //}

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Move(int rnd)
    {
        float randomPos = Random.Range(-1.75f, -6f);

        if (rnd != 10)
            transform.DOMoveY(randomPos, Mathf.Clamp(randomPos,0.4f,1f)).SetEase(ease);

        StartCoroutine(delay("rnd"));
    }

    //range 
    public void Moveup(int rnd)
    {
        if (rnd != 10)
            transform.DOMoveY(-1.75f, 1f).SetEase(ease);

        StartCoroutine(delay("Down"));
    }

    public void Movedown(int rnd)
    {
        if (rnd != 10)
            transform.DOMoveY(-6, 1f).SetEase(ease);

        StartCoroutine(delay("Up"));
    }

    IEnumerator delay(string movement)
    {
        for (float i = 0; i <= 1; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        switch (movement)
        {
            case "Up":
                Moveup(Random.Range(0, 11));
                break;

            case "Down":
                Movedown(Random.Range(0, 11));
                break;

            case "rnd":
                Move(Random.Range(0, 11));
                break;
        }
    }

    IEnumerator MoveDown()
    {
        while (transform.position.y > -6)
        {
            int rnd = Random.Range(0, 11);

            transform.DOMoveY(transform.position.y - 0.1f, 0.1f).SetEase(Ease.InBounce);
            //transform.position = new Vector2(transform.position.x, transform.position.y - 0.08f);

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
        while (transform.position.y < -1.75f)
        {
            int rnd = Random.Range(0, 11);

            transform.DOMoveY(transform.position.y + 0.1f, 0.1f).SetEase(Ease.InBounce);

            //transform.position = new Vector2(transform.position.x, transform.position.y + 0.08f);

            if (rnd != 10)
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
