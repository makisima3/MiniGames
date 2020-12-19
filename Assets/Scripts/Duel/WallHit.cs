using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    public int HP = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP--;

        if(HP <= 0)
        {
            WallSpawner.Instance.SpawnWall();

            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }
}
