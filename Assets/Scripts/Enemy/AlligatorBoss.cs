using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorBoss : MonoBehaviour
{
    public enum AlligatorState
    {
        Spawn,
        Run,
        Attack
    }

    [Header("States")]
    [SerializeField] private AlligatorState _currentState = AlligatorState.Spawn;

    [Header("Movement")]
    [SerializeField] private float _movementSpeed = 8;

    [SerializeField] private Vector3 _initialPos;

    private void Update()
    {
        switch(_currentState)
        {

            case AlligatorState.Spawn:
                Spawn();
                break;

            case AlligatorState.Run:
                Movement();
                break;

            case AlligatorState.Attack:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Reset();
        }
    }

    private void Reset()
    {
        _currentState = AlligatorState.Spawn;
    }

    private void Attack()
    {
        throw new NotImplementedException();
    }

    private void Spawn()
    {
        transform.position = _initialPos;
    }

    public void Movement()
    {
        transform.Translate(new Vector3(0,0, _movementSpeed * Time.deltaTime));
    }
}
