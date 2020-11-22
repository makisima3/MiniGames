using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTriger : MonoBehaviour
{
    private Rigidbody2D playerRB;


    [SerializeField] private GameObject bloodParticlePrefab;
    [SerializeField] private GameObject player1, player2;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("LOG");
            var contact = collision.contacts[0];
            Instantiate(bloodParticlePrefab, contact.point, Quaternion.identity);

            if (name == "Player1")
            {
                PlayersScore.instanse.Player1HP--;

                PlayersScore.instanse.Player1HPText.text = "HP = " + PlayersScore.instanse.Player1HP;

                if (PlayersScore.instanse.Player1HP <= 0)
                {
                    StartCoroutine(GameOver.instance.GameOverDelay("Player2"));
                    //Destroy(player1.GetComponent<HitTriger>());
                }
            }

            if (name == "Player2")
            {
                PlayersScore.instanse.Player2HP--;

                PlayersScore.instanse.Player2HPText.text = "HP = " + PlayersScore.instanse.Player2HP;

                if (PlayersScore.instanse.Player2HP <= 0)
                {
                    StartCoroutine(GameOver.instance.GameOverDelay("Player1"));
                    //Destroy(player1.GetComponent<HitTriger>());

                }
            }


        }

        Destroy(collision.gameObject);
    }

    
}
