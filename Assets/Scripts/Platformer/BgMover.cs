using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMover : MonoBehaviour
{
    public float speed = -0.1f;

    public GameObject firtPlatform, SecondPlatform;

    public float timespeedChage = 5f;

    private void Start()
    {
        StartCoroutine(TiemSpeedSetter());
    }

    private void Update()
    {
        firtPlatform.transform.position += new Vector3(speed, 0);
        SecondPlatform.transform.position += new Vector3(speed, 0);

        if (firtPlatform.transform.position.x <= -19.976f)
            firtPlatform.transform.position = new Vector2(19.976f, 0);

        if (SecondPlatform.transform.position.x <= -19.976f)
            SecondPlatform.transform.position = new Vector2(19.976f, 0);

        if (TrapSpawner.Instance.CurrentTrup != null)
        {
            TrapSpawner.Instance.CurrentTrup.transform.position += new Vector3(speed, 0);
        }
    }

    IEnumerator TiemSpeedSetter()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(timespeedChage);

            speed -= 0.02f;
        }
    }
}
