using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScore : MonoBehaviour
{

    public static PlayersScore instanse { get; set; }

    [SerializeField] public int startHP = 2;
    public int Player1HP, Player2HP;

    public Text Player1HPText, Player2HPText;
    // Start is called before the first frame update
    void Start()
    {
        instanse = this;

        Player1HP = startHP;
        Player2HP = startHP;

        Player1HPText.text = "HP = " + Player1HP;
        Player2HPText.text = "HP = " + Player2HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
