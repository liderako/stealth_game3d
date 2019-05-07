using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemy : MonoBehaviour
{
    public GameObject _positionNextPoint;

    void Start()
    {
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "enemy.png", false);
    }
}
