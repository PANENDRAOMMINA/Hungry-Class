using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using TMPro;

public class Tray : MonoBehaviour
{
    //number of food items 
    public TextMeshProUGUI Number_Of_FoodItems;
    // Number of Choosen food object 
    public Food_Item Choosen_food_Object;

    // Update is called once per frame
    void Update()
    {
        Number_Of_FoodItems.text=Choosen_food_Object.Number_of_Fooditems.ToString();
    }
}
