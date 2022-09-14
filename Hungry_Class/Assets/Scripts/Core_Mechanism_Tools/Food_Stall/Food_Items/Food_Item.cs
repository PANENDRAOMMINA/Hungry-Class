using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Item : MonoBehaviour
{


    //Common parameters for Food_Item
    public int Energy;
    private Camera mainCamera;
    public bool is_dragging;
    public Vector3 my_place;
    public Human Choosen_Human;
    
    public bool Being_Eaten;
    public int Number_of_Fooditems;
    public int Eating_Time;

    private void Awake() 
    {
        Set_Camera();
    }
    

    private void Set_Camera()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    
    //dragging the food in the screen 
    private void OnMouseDrag()
    {
        Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
        is_dragging=true;
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            transform.position=new Vector3(raycastHit.point.x,2,raycastHit.point.z);
        }
    }
    
    private  void OnMouseUp()
    {
        
        is_dragging = false;
        if (Choosen_Human != null)//checks whether human is present or not
            if (Choosen_Human.had_food)//if the food item is with human
            {
                StartCoroutine(Eating(Eating_Time));
            }
       if(Choosen_Human==null) //if there is no human selected then ..
             Reset_Position();
            
    }

    private void Reset_Position()
    {
        // if the number of food items are greater than 0
        if (Number_of_Fooditems > 0) 
            transform.position = my_place;
        else
            this.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //if food object is in contact with the human 
        if(other.gameObject.CompareTag("Human"))
        {
            Choosen_Human=other.gameObject.GetComponent<Human>();
            Choosen_Human.had_food=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if the food object is not in contact with the human , 
          so the food object chooses the human null ( why because there are
          no humans right ?? )
        */
        
        if(other.gameObject.CompareTag("Human"))
        {
            other.gameObject.GetComponent<Human>().had_food=false;
            Choosen_Human=null;
        }
    }
/* When the human is eating , 
    the human energy will rises
    the human will not have the food anymore since he eats the food
*/
    IEnumerator Eating(float time)
   {
        Choosen_Human.had_food=false;
        Number_of_Fooditems--;
        Choosen_Human.is_eating=true;
        yield return new WaitForSecondsRealtime(time);
        Choosen_Human.is_eating=false;
        Choosen_Human.Eaten(Energy);
        Choosen_Human=null;
        Reset_Position();
   }
    
}
