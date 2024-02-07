using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class Player_Nav : MonoBehaviour
{

    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        
    }

   public void MoveToTarget(Vector3 point)
   {

    agent.SetDestination(point);

    
   }


}
