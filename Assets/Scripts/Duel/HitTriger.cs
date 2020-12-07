using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Duel
{
    public class HitTriger : MonoBehaviour
    {
        public PlayerScore playerScore;

        private bool isGameOver = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (GetComponent<PlayerController>().hp >= 0)
                GetComponent<PlayerController>().hp--;
            if(GetComponent<PlayerController>().hp <= 0)
            {
                StartCoroutine(GetComponent<PlayerController>().PlayerFinish());
                StopCoroutine(GetComponent<PlayerController>().shoot);
                StopCoroutine(GetComponent<PlayerController>().reload);
            }
            
            if (this.name == "Player1")
            {
                if (playerScore.player1Hp.Count - 1 >= 0)
                {
                    Destroy(playerScore.player1Hp[playerScore.player1Hp.Count - 1]);
                    playerScore.player1Hp.RemoveAt(playerScore.player1Hp.Count - 1);
                }
            }
            else
            {
                if (playerScore.player1Hp.Count - 1 >= 0)
                {
                    Destroy(playerScore.player2Hp[playerScore.player2Hp.Count - 1]);
                    playerScore.player2Hp.RemoveAt(playerScore.player2Hp.Count - 1);
                }
            }

            

            Destroy(collision.gameObject);
        }
    }
}
