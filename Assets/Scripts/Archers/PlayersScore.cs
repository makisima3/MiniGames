using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScore : MonoBehaviour
{

    public static PlayersScore instanse { get; set; }

    public GameObject hpPoint1, hpPoint2, RedheartPrefab, blueheartPrefab;

    public List<GameObject> player1Hp;
    public List<GameObject> player2Hp;

    public int distance = 10;

    [SerializeField] public int startHP = 2;
    public int Player1HP, Player2HP;

    public Text Player1HPText, Player2HPText;
    // Start is called before the first frame update
    void Start()
    {


        instanse = this;

        player1Hp = new List<GameObject>();
        player2Hp = new List<GameObject>(); ;
        Player1HP = startHP;
        Player2HP = startHP;

        Player1HPText.text = "HP = " + Player1HP;
        Player2HPText.text = "HP = " + Player2HP;

        for (int i = 0; i < startHP; i++)
        {
            var heartPlayer1 = Instantiate(RedheartPrefab);
            heartPlayer1.name = heartPlayer1.name + i;
            heartPlayer1.transform.SetParent(hpPoint1.transform);
            heartPlayer1.transform.position = new Vector2(hpPoint1.transform.position.x +(distance * i), hpPoint1.transform.position.y);

            var heartPlayer2 = Instantiate(blueheartPrefab);
            heartPlayer2.name = heartPlayer2.name + i;
            heartPlayer2.transform.SetParent(hpPoint2.transform);
            heartPlayer2.transform.position = new Vector2(hpPoint2.transform.position.x + (distance * -i), hpPoint2.transform.position.y);

            player1Hp.Add(heartPlayer1);

            player2Hp.Add(heartPlayer2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
