using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/*this is just the attributes that holds values for spawning the 
food item if you see a food item spawning on the screen after play
this is happening due to the script*/
//[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List")]
public class Food_Item_Spawn 
{
   public GameObject Food_Item;
    //public float energy;
    //public float timetoeat;
   public float Basket_Position_Left;
   public int Number_of_Fooditems;
}
