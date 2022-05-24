using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    [SerializeField] private Transform[] _target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float _targetDistance;
    private int _actualTarget;
    public bool isGrounded = true;
    // Update is called once per frame

    private void Start()
    {
        _actualTarget = 1;
    }

    void Update()
    {

        if(isGrounded)
        {
            transform.position = Vector3.MoveTowards(transform.transform.position, _target[_actualTarget].position, moveSpeed * Time.deltaTime);
        }
        

        if(_targetDistance > Vector3.Distance(transform.position,_target[_actualTarget].position))
        {
            if(_actualTarget == 1)
            {
                _actualTarget = 0;
            }
            else 
            {
                _actualTarget = 1;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(_target[0].position, _targetDistance);
        Gizmos.DrawSphere(_target[1].position, _targetDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GetInstance.ResetScene();
        }
    }
}
