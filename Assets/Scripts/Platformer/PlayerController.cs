using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Platformer
{
    public class PlayerController : MonoBehaviour, IPointerDownHandler
    {
        private bool onGround = false;
        [SerializeField]private Transform groundChek;
        [SerializeField] private float groundRadius = 0.2f;
        [SerializeField] private LayerMask wtfIsGround;

        public Rigidbody2D PlayerRb;

        public float jumpForce;

        private void Awake()
        {
           
        }

        public void Jump()
        {

            onGround = Physics2D.OverlapCircle(groundChek.position, groundRadius, wtfIsGround);

            if (onGround)
                PlayerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Jump();

            Debug.Log("fgf");
        }
    }
}
