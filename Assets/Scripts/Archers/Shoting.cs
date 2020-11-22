using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoting : MonoBehaviour
{
    //public Text text;
    [SerializeField] public Rigidbody2D playerRigidbody2d;
    [SerializeField] private Rigidbody2D arrow;

    [SerializeField] private bool isPressed = false;
    [SerializeField] private float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPressed == true)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(Vector2.Distance(mousePosition,playerRigidbody2d.position) > maxDistance)
            {
                arrow.position = playerRigidbody2d.position + (mousePosition - playerRigidbody2d.position).normalized * maxDistance;
            }
            else
            {
                arrow.position = mousePosition;
            }

        }




    }

    private void OnMouseDown()
    {
        isPressed = true;
        arrow.isKinematic = true;

    }

    private void OnMouseUp()
    {
        isPressed = false;
        arrow.isKinematic = false;

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        //this.enabled = false;
    }

}
