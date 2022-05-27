using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public enum EnemyState
    {
        Walking,
        Death
    }


    [SerializeField] private EnemyState _currentState;
    [SerializeField] private float _rotationSpeed = 15;
    [SerializeField] private float _moveSpeed = 5;
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

        if(isGrounded)
        {
            if(xAxis)
            {
                _rb.AddForce(new Vector3(_moveSpeed, 0, 0));
            }
            else
            {
                _rb.AddForce(new Vector3(0, 0, _moveSpeed));
            }
            
        }

        if(_currentState == EnemyState.Death)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GetInstance.ResetScene();
        }
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.CompareTag("EnemyTargetUbi"))
        {
            _moveSpeed = -1 * _moveSpeed;
        }
        if (other.CompareTag("Spikes"))
        {
            _currentState = EnemyState.Death;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
