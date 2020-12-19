using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrupTrigger : MonoBehaviour
{

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            TrapSpawner.Instance.GameOver();
        else
        {
            TrapSpawner.Instance.TrapSpawn();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TrapSpawner.Instance.GameOver();
        else
        {
            TrapSpawner.Instance.TrapSpawn();
            Destroy(this.gameObject);
        }
    }
}
