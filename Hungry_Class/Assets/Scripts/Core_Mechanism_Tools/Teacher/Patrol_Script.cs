using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

/*patrol script inspired from blackthorn prod youtube channel */

public class Patrol_Script : MonoBehaviour
{
    public GameObject[] patrol_points;
    public int currentPointIndex;
    public int wait_time;

    public bool is_flag;
    public bool Stop;
    public NavMeshAgent agent;
    

    private void Awake() 
    {
       agent = this.GetComponent<NavMeshAgent>();    

    }


    private void Update()
    {
        
            pursue();
         
            /*if (Vector3.Distance(this.transform.position, playerPos) < 5)
            {
                EnemyCube.speed = 3;
                // this.transform.LookAt(player.transform.position);
                followandshoot(playerPos);
                //  Debug.Log("PlayerPos"+playerPos);
                if (Physics.Raycast(ray, out rayHit, raylength))
                {
                    if (rayHit.collider.CompareTag("Player"))
                    {
                        //this.transform.LookAt(player.transform.position);
                        if (isShooting)
                        {
                            return;
                        }
                        StartCoroutine(Shoot());

                        // StartCoroutine(shoot());

                    }
                }
            }
            else
            {
                EnemyCube.isStopped = false;
                //Debug.Log("targetCantsee" + TargetCanSee());
                pursue();
            }*/


            /*if (transform.position!=patrol_points[currentPointIndex].transform.position)
            {   
                agent.SetDestination(patrol_points[currentPointIndex].transform.position);
               // transform.position=Vector3.MoveTowards(transform.position,patrol_points[currentPointIndex].transform.position,3*Time.deltaTime);
            }*/
             
              
            
               //Rotate();
         }
        
        void seek(Vector3 location)
        {
            agent.SetDestination(location);
        }
    void pursue()
    {
        agent.speed = 2;
        seek(patrol_points[currentPointIndex].transform.position);
        //Debug.Log(agent.remainingDistance);
        if (Vector3.Distance(agent.transform.position, patrol_points[currentPointIndex].transform.position) < 1)
        {   
            if(currentPointIndex == patrol_points.Length-1)  
            {
                currentPointIndex = 0;

            }
            else
            {
                currentPointIndex++;
            }
            // = Random.Range(0, gb.Length);
            //Debug.Log("Start pursue" + currentWaypoint);

        }
        
       /* if (agent.remainingDistance==0 )
        {
            if (currentPointIndex > patrol_points.Length)
            {
                currentPointIndex = 0;
            }
            else
            {
                currentPointIndex++;
            }
            
                // = Random.Range(0, gb.Length);
                                    //Debug.Log("Start pursue" + currentWaypoint);

        }*/
    }


    /*private void Rotate()
    {
        
        Vector3 targetDirection = patrol_points[currentPointIndex].position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 2 * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        
    }   
    /*IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(wait_time);
         if(currentPointIndex+1<patrol_points.Length)
         {
             currentPointIndex++;
         }
         else
         {
             currentPointIndex=0;
         }
         is_flag=false;
        
    }*/
}
