using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlField : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Player;

    private PlayerController playerController;
    private Vector2 startTouchPosition;

    private void Awake()
    {
        playerController = Player.GetComponent<PlayerController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(startTouchPosition.x - eventData.position.x > 0)
        {
            playerController.MoveLeft();
        }
        else
        {
            playerController.MoveRight();
        }

        startTouchPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        playerController.Jump();
    }
}
