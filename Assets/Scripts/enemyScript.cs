using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public GameObject targetObject;
    NavMeshAgent agent;

    public GameObject[] patrolPath;
    public int pathIndex = 0;
    private bool movementCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(targetObject.transform.position);

        if(patrolPath.Length != 0)
        {
            agent.SetDestination(patrolPath[pathIndex].transform.position);
            if (agent.velocity == new Vector3(0, 0, 0) && movementCheck == false) 
            {
                movementCheck = true;
                pathIndex++;
                if(pathIndex >= patrolPath.Length)
                {
                    pathIndex = 0;
                }
            }

            if (agent.velocity != Vector3.zero)
            {
                movementCheck = false;
            }

        }
    }
}
