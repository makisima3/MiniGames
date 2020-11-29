using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChocolateWallController : MonoBehaviour
{
    [SerializeField] private float downDelay = 0.2f;
    [SerializeField] private float upDelay = 1f;
    [SerializeField] private Ease easeOnDown = Ease.Flash, easeOnUp = Ease.Flash;
    [SerializeField] private Vector2 positionYWhenWallUp, positionYWhenWallDawn;

   
    // Start is called before the first frame update
    void Start()
    {
        WallDown();
    }

    public void WallDown()
    {
        transform
            .DOMoveY(positionYWhenWallDawn.y, downDelay)
            .SetEase(easeOnDown)
            .OnComplete(WallUp);
    }

    public void WallUp()
    {
        transform
            .DOMoveY(positionYWhenWallUp.y, upDelay)
            .SetEase(easeOnUp)
            .OnComplete(WallDown);
    }
}
