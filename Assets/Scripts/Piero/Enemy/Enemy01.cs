using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public enum EnemyState
    {
        Walking,
        Falling,
        Death

    }


    [SerializeField] private EnemyState _currentState;
    [SerializeField] private float _rotationSpeed = 15;
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private float _gravitySpeed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool xAxis = true;
    public bool isGrounded = true;
    // Update is called once per frame

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        switch(_currentState)
        {
            case EnemyState.Walking:
                Walking();
                break;

            case EnemyState.Death:
                Death();
                break;

            case EnemyState.Falling:
                Falling();
                break;
        }
    }

    private void Falling()
    {
        _rb.velocity += new Vector3(0, -_gravitySpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("EnemyTargetUbi"))
        {
            _moveSpeed = -1 * _moveSpeed;
        }

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
    private void Walking()
    {
        _rb.velocity = new Vector3(0,0, _moveSpeed);

        if (!isGrounded) 
        {
            _currentState = EnemyState.Falling;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
