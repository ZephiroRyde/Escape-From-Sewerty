using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlatform : MonoBehaviour
{
    public GameObject Lever;
    LeverMove leverMove;
    [SerializeField] Vector3 _targetPosition;
    [SerializeField] float _speed = 10;
    private Vector3 _initialPosition;
    [SerializeField] private bool _back = false;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private Transform _playerTransform;
    private void Awake()
    {
        leverMove = Lever.GetComponent<LeverMove>();
        _initialPosition = transform.position;
    }
    void Update()
    {
        if (transform.position == _targetPosition)
        {
            _back = true;
            _isMoving = false;
        }
        else if (transform.position == _initialPosition)
        {
            _back = false;
            _isMoving = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && _isMoving == false && leverMove.LeverActivation == true)
        {
            _isMoving = true;
        }
        if (_isMoving == true && _back == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        }
        else if (_isMoving == true && _back == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _initialPosition, _speed * Time.deltaTime);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerTransform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerTransform.SetParent(null);
    }
}
