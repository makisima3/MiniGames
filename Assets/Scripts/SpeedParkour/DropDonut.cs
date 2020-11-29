using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DropDonut : MonoBehaviour, IMoveHandler
{
    [SerializeField] public float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float dropDelay = 3f;
    [SerializeField] Transform dropSpawnPoint;

    private bool onMove = false;
    private Rigidbody2D dropDonutRigidBody2D;

    private void Awake()
    {
        dropDonutRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = dropSpawnPoint.position;
        dropDonutRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {

    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);

        onMove = true;
        dropDonutRigidBody2D.AddForce(Vector2.left * speed, ForceMode2D.Impulse);

        StartCoroutine(delay2());
    }

    IEnumerator delay2()
    {
        yield return new WaitForSeconds(dropDelay);

        onMove = false;
        dropDonutRigidBody2D.velocity = Vector2.zero;
        dropDonutRigidBody2D.angularVelocity = 0;

        Start();
    }

    private void FixedUpdate()
    {
        if (onMove)
        {
            Quaternion rotation = Quaternion.AngleAxis(rotationSpeed, Vector3.forward);
            transform.rotation *= rotation;
        }

    }

    public void OnMove(AxisEventData eventData)
    {


    }
}
