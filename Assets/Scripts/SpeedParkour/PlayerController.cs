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
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void MoveLeft()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isRunning", true);

        transform.rotation = new Quaternion(0, 180, 0, 1);

        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isRunning", true);

        transform.rotation = new Quaternion(0, 0, 0, 1);

        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", true);

        onGround = Physics2D.OverlapCircle(groundChek.position, groundRadius, wtfIsGround);

        if (onGround)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


}
