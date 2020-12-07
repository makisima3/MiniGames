using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Duel
{
    public class PlayerFieldController : MonoBehaviour, IPointerClickHandler
    {
        public GameObject Player;

        public void OnPointerClick(PointerEventData eventData)
        {
            var move = Player.GetComponent<PlayerController>().moveUp;

            if(move == true)
            {
                Player.GetComponent<PlayerController>().moveUp = false;
            }
            else
            {
                Player.GetComponent<PlayerController>().moveUp = true;
            }
        }
    } 
}
