using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]private GameObject _camera;
    [SerializeField] private float _speed;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.rotation = Quaternion.Euler(0.0f, _camera.transform.rotation.eulerAngles.y, 0.0f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(_transform.forward * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(-_transform.forward * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(_transform.right * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(-_transform.right * _speed, ForceMode.Force);
        }
    }
}
