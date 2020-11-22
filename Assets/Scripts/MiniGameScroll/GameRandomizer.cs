using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRandomizer : MonoBehaviour
{
    public Sprite[] resoucesSprites;
    private Sprite[] spritesForRoll;
    public Image resultImage;
    public float rollSpeed = 0.01f;

    private bool isRoll = false;
    private int rollCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollBattron_click()
    {
        rollCount = Random.Range(100, 110);

        FillSpritesForRoll();

        StartCoroutine(SimulateRullet());
    }

    IEnumerator SimulateRullet()
    {
        rollSpeed = 0.01f;

        for (int i = 0; i < rollCount; i++)
        {
            resultImage.sprite = spritesForRoll[i];

            yield return new WaitForSeconds(rollSpeed);

            rollSpeed += 0.001f;
        }
    }

    public void FillSpritesForRoll()
    {
        spritesForRoll = new Sprite[rollCount];
        for (int i = 0; i < rollCount; i++)
        {
            spritesForRoll[i] = resoucesSprites[Random.Range(0, resoucesSprites.Length)];
        }
    }

}
