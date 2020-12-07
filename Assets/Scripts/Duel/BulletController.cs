using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed =10f;

    private bool moveLeft;
    private Vector2 direction;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (transform.position.x > 0)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
        DoMove();
    }

    public void DoMove()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
