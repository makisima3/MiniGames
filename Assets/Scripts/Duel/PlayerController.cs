using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Duel
{
    public class PlayerController : MonoBehaviour
    {
        public bool moveUp;
        public float speed = 0.2f;
        public Transform bulletSpawner;

        public int hp = 3;

        public GameObject bulletPrefab;
        public float reloarSpeed = 1;
        public float shootSpeed = 1;
        public int shootCount = 3;
        public bool isFinish = false;
        public IEnumerator shoot,reload;

        private Rigidbody2D rg;

        private void Awake()
        {
            rg = GetComponent<Rigidbody2D>();
            shoot = Shoot();
            reload = Reload();
        }

        private void Start()
        {
            int a = Random.Range(0, 2);

            if (a == 0)
                moveUp = true;
            else
                moveUp = false;
            DoMove();

            StartCoroutine(Reload());
        }

        private void Update()
        {
            DoMove();

            //if(hp <= 0)
            //{
            //    if(isFinish)
            //    {
            //        StartCoroutine(PlayerFinish());
            //    }
                
            //}
        }

        private void DoMove()
        {
            if (moveUp == true)
            {
                if (transform.position.y <= 3)
                {
                    var moveForce = new Vector3(0, speed);
                    transform.position += moveForce;
                }

            }
            else
            {
                if (transform.position.y >= -3)
                {
                    var moveForce = new Vector3(0, -speed);
                    transform.position += moveForce;
                }
            }
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloarSpeed);

            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            for (int i = 0; i < shootCount; i++)
            {
                var newBullet = Instantiate(bulletPrefab, null);
                newBullet.transform.position = bulletSpawner.position;
                yield return new WaitForSeconds(shootSpeed);
            }

            StartCoroutine(Reload());
        }

        public IEnumerator PlayerFinish()
        {
            for (float i = 1; i > 0; i -= 0.1f)
            {
                Time.timeScale = i;
                yield return new WaitForSeconds(0.01f);
            }

            Time.timeScale = 0;
        }

    }
}