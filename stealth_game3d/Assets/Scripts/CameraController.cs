using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform _transformPlayer;

    private Vector3 _offset;
    private float _rotationX;
    private float _rotationY;
    private Transform _transform;

    private const float _speedRotate = 10.0f;
    private const float _maxAngleX = 45.0f;
    private const float _minAngleX = -45.0f;

    void Start()
    {
        _transform = transform;
        _offset = _transform.position - _transformPlayer.position;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        _transform.Rotate(0, Input.GetAxis("Mouse X") * _speedRotate, 0);
        _rotationX -= Input.GetAxis("Mouse Y") * _speedRotate;
        _rotationX = Mathf.Clamp(_rotationX, _minAngleX, _maxAngleX);
        _rotationY = _transform.localEulerAngles.y;
        _transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }

    private void Move()
    {
        _transform.position = _transformPlayer.position + _offset;
    }
}
