using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(currentPoint.transform.position);
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            currentPoint = currentPoint.GetComponent<PointEnemy>()._positionNextPoint;

        }
    }
}
