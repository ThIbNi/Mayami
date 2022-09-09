using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Player player;
    private Vector3 DistanceToPlayer;
    private Vector3 CoordsEnemy;
    private float MaxDistance;
    private float MinDistance;
    private float ActualDistance;

    // Start is called before the first frame update
    void Start()
    {
        //MaxDistance = new Vector3(20.0f, 0.0f, 20.0f);
        MaxDistance = 20f;
        MinDistance = 5f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = player.transform.position;
        CoordsEnemy = transform.position;
        ActualDistance = Vector3.Distance(DistanceToPlayer, CoordsEnemy);

        if (ActualDistance < MaxDistance)
        {
            if (ActualDistance < MinDistance)
            {
                navMeshAgent.SetDestination(CoordsEnemy);
            }
            else
            {
                navMeshAgent.SetDestination(DistanceToPlayer);
            }
        }
    }
}
