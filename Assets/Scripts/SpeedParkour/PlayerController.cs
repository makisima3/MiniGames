using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool onGround = false;
    [SerializeField] private Transform groundChek;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask wtfIsGround;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        onGround = Physics2D.OverlapCircle(groundChek.position, groundRadius, wtfIsGround);

        if (onGround)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


}
