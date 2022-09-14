using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* here comes AI sensor , the teachers main power , checks the students eating or not 
   if the teacher finds then the game is over */

[ExecuteInEditMode]
public class Ai_Sensor : MonoBehaviour
{
    [SerializeField]
    public GameObject Parent_class;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Human")
        {
            if (other.GetComponent<Human>().is_eating)
            {
                Game_Over();
            }
        }
    }

    private void Game_Over()
    {
        Parent_class.GetComponent<Patrol_Script>().Stop = true;
        GameManager._instance.SetGameState(GameState.GAME_OVER);
    }
}
