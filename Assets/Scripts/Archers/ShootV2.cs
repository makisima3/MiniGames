using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootV2 : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField] public GameObject arrowPrefab;
    [SerializeField] public GameObject Player;
    [SerializeField] public TrajectoryRenderer trajectory;

    public float shootForce = 10;

    private Vector2 startMousePosition, endMousePosition;

    private GameObject newArrow;

    // Start is called before the first frame update
    void Start()
    {
        newArrow = Instantiate(arrowPrefab);

        newArrow.transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startMousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        //Debug.Log(startMousePosition);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        endMousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        trajectory.lineRendererComponent.positionCount = 0;
        //Debug.Log(endMousePosition);
        //Debug.Log(endMousePosition - startMousePosition);
        if (newArrow != null)
        {
            
            newArrow.GetComponent<Rigidbody2D>().isKinematic = false;
            newArrow.GetComponent<Rigidbody2D>().AddForce(startMousePosition - endMousePosition * shootForce, ForceMode2D.Impulse);
            newArrow = null;
            StartCoroutine(Reload());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        endMousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        trajectory.ShowTrajectory(Player.gameObject.transform.position, startMousePosition - endMousePosition * shootForce);
        //Debug.Log(startMousePosition - endMousePosition * shootForce);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);

        newArrow = Instantiate(arrowPrefab);

        newArrow.transform.position = Player.transform.position;
    }

 
}
