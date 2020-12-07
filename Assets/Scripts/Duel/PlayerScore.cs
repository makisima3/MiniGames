using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Duel
{
    public class PlayerScore : MonoBehaviour
    {

        public PlayerController PlayerController;
        public GameObject hpPoint1, hpPoint2, RedheartPrefab, blueheartPrefab;

        public List<GameObject> player1Hp;
        public List<GameObject> player2Hp;

        public int distance = 10;

        private int hp = 3;

        
        // Start is called before the first frame update
        void Start()
        {
            hp = PlayerController.hp;

            player1Hp = new List<GameObject>();
            player2Hp = new List<GameObject>();

            for (int i = 0; i < hp; i++)
            {
                var heartPlayer1 = Instantiate(RedheartPrefab);
                heartPlayer1.name = heartPlayer1.name + i;
                heartPlayer1.transform.SetParent(hpPoint1.transform);
                heartPlayer1.transform.position = new Vector2(hpPoint1.transform.position.x + (distance * i), hpPoint1.transform.position.y);

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
}
