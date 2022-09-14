using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall : MonoBehaviour 
{
    public Food_Item_Spawn[] Food_Item_Spawn;
    public GameObject Food_Object_Tray;
    public static Stall instance;

    private void Awake()
    {
        //Singleton();
        Setup_FoodItems();
    }

    private void Singleton()
    {
        if (instance == null)
            instance = this;
    }
/* this is the setup of food stall where it sets up 
food items and baskets*/
    private void Setup_FoodItems()
    {
        for (int i = 0; i < Food_Item_Spawn.Length; i++)
        {
            Vector3 Food_item_Position = new Vector3(Food_Item_Spawn[i].Basket_Position_Left, 2.5f, -9.5f);
            Vector3 tray_position = new Vector3(Food_Item_Spawn[i].Basket_Position_Left, 1.35f, -9.5f);
            GameObject _tray=Instantiate(Food_Object_Tray,tray_position,Quaternion.identity);
            GameObject food_item=Instantiate(Food_Item_Spawn[i].Food_Item, Food_item_Position, Quaternion.identity);
            _tray.GetComponent<Tray>().Choosen_food_Object=food_item.GetComponent<Food_Item>();
            food_item.GetComponent<Food_Item>().my_place = Food_item_Position;
            food_item.GetComponent<Food_Item>().Number_of_Fooditems=Food_Item_Spawn[i].Number_of_Fooditems;
        }
    }
}
