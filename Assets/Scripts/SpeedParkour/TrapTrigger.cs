using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = spawnPoint.position;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = spawnPoint.position;
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * GetComponent<DropDonut>().speed, ForceMode2D.Impulse);
        }
        
    }
}
