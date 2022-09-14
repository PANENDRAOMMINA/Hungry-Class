using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/* Humans are the main game object in a game , every human has hunger index
and it needs food . if the human has 0 energy , the game is lost */

public class Human : MonoBehaviour
{

   public bool is_eating=false;
   public bool had_food;
   public int Hunger;

   
   public float slider_Energy_Constant=0.1f;

   public Slider Hunger_Food;

   private void Awake()
   {
      Hunger_Food.value=1;
     // slider_Energy_Constant=Hunger_Food.value/Hunger;
   }


   // energy decreases per time 
   private void Update()
   {
      Decrease_Energy();
      if(Hunger_Food.value==0)
      {
            GameManager._instance.SetGameState(GameState.GAME_OVER);
      }
   }

    private void Decrease_Energy()
    {
        Hunger_Food.value-=slider_Energy_Constant*Time.deltaTime;
    }


    public void Eaten(int x)
   {
      GameManager._instance.Increase_Progress();
      Hunger_Food.value+=slider_Energy_Constant*x;  
   }
   
}
