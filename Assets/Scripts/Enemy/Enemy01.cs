using System;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
public class Enemy01 : MonoBehaviour
{
    public enum EnemyState
    {
        Walking,
        Running,
        Falling,
        Death

    }



    [SerializeField] private EnemyState _currentState;
    [SerializeField] private float _walkSpeed = 5;
    [SerializeField] private float _runSpeed = 8;
    [SerializeField] private float _gravitySpeed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool xAxis = true;
    [SerializeField] private Transform _model;
    [SerializeField] private Animator _selfAnimator;
    [SerializeField] private bool _der;

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

            case EnemyState.Running:
                Running();
                break;

            case EnemyState.Death:
                Death();
                break;

            case EnemyState.Falling:
                Falling();
                break;
        }
    }

    private void Running()
    {
        if (xAxis)
        {
            _rb.velocity = new Vector3(0, 0, _walkSpeed);
        }
        else
        {
            _rb.velocity = new Vector3(_walkSpeed, 0, 0);
        }


        if (!isGrounded)
        {
            _currentState = EnemyState.Falling;
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
            _walkSpeed = -1 * _walkSpeed;
            _runSpeed = -1 * _runSpeed;

            if(xAxis)
            {

                if (_der)
                {
                    _model.DORotate(new Vector3(0, 180, 0), 0.5f).OnComplete(() => { _der = !_der; });
                }
                else
                {
                    _model.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => { _der = !_der; });
                }
            }
            else 
            {
                if (_der)
                {
                    _model.DORotate(new Vector3(0, -90, 0), 0.5f).OnComplete(() => { _der = !_der; });
                }
                else
                {
                    _model.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() => { _der = !_der; });
                }
                
            }
            
        }

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.CompareTag("Spikes"))
        {
            _currentState = EnemyState.Death;
        }
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetPlayerController.SavePointTeleport();
        }

    }
    private void Walking()
    {


        if(xAxis)
        {
            _rb.velocity = new Vector3(0, 0, _walkSpeed);
        }
        else
        {
            _rb.velocity = new Vector3(_walkSpeed, 0, 0);
        }
        

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
