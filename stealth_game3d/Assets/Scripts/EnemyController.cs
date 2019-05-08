using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _lastPositionPlayer;

    [SerializeField]private bool _isPlayerTarget;
    [SerializeField]private GameObject _currentPoint;
    [SerializeField]private Transform _playerTransform;


    private bool _isLook;
    private bool _isPatrol;
    private bool _isAttention;
    private const int _layerPlayer = 8;
    private const float _speedPatrol = 1.5f;
    private const float _speedHunt = 2.3f;
    private const float _rangeVision = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _isPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePatrol();
        MoveHunt();
        MoveToLastPositionPlayer();
    }

    private void LateUpdate()
    {
       RayCastingEye();
    }

    private void RayCastingEye()
    {
        float yStart = -30.0f;
        float step = 5.0f;
        int amountRay = 13;
        bool tmpLook = false;
        RaycastHit hit;

        for (int i = 0; i < amountRay; i++)
        {
            Vector3 dir = Quaternion.Euler(0, yStart, 0) * (_agent.transform.forward * _rangeVision);
            if (Physics.Raycast(transform.position, dir, out hit, _rangeVision))
            {
                if (hit.transform.gameObject.layer == _layerPlayer)
                {
                    tmpLook = true;
                    /*
                    Debug.DrawRay(
                        _agent.transform.position,
                        dir,
                        Color.white);
                    */
                    break;
                }
            }
            yStart += step;
        }
        if (!tmpLook && _isLook)
        {
            RememberPlayer();
        }
        if (tmpLook)
        {
            LookOnPlayer();
        }
    }

    private void MovePatrol()
    {
        if (!_isPatrol)
        {
            return;
        }
        _agent.SetDestination(_currentPoint.transform.position);
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _currentPoint = _currentPoint.GetComponent<PointEnemy>()._positionNextPoint;
        }
    }

    private void MoveHunt()
    {
        if (!_isLook)
        {
            return;
        }
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(_playerTransform.position);
        }
    }

    private void MoveToLastPositionPlayer()
    {
        if (!_isAttention)
        {
            return;
        }
        _agent.SetDestination(_lastPositionPlayer);
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            PatrolStart();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == _layerPlayer)
        {
            LookOnPlayer();
        }
    }

    private void PatrolStart()
    {
        _isPatrol = true;
        _agent.speed = _speedPatrol;
        _isAttention = false;
        _isLook = false;
    }

    private void RememberPlayer()
    {
        _isLook = false;
        _isAttention = true;
        _lastPositionPlayer = _playerTransform.position;
    }

    private void LookOnPlayer()
    {
        _isPatrol = false;
        _isAttention = false;
        _agent.speed = _speedHunt;
        _isLook = true;
    }
}
