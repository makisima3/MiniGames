using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrowRb2d;

    // Start is called before the first frame update
    void Start()
    {
        arrowRb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowRb2d.velocity != Vector2.zero)
        {
            StartCoroutine(isTrigger());
            float angle = Quaternion.LookRotation(arrowRb2d.velocity.normalized).eulerAngles.x;

            if (name == "Player1Arrow(Clone)")
                transform.rotation = Quaternion.Euler(Vector3.forward * -angle);

            if (name == "Player2Arrow(Clone)")
                transform.rotation = Quaternion.Euler(Vector3.back * -angle);
        }

        if(Time.timeScale <= 0.9)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator isTrigger()
    {
        yield return new WaitForSeconds(0.1f);

        GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}
