using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlatform : MonoBehaviour
{
    public GameObject Lever;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _speed = 10;
    [SerializeField] private bool _backToOrigin = false;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private Transform _playerTransform;
    private Vector3 _initialPosition;
    LeverMove leverMove;

    private void Awake()
    {
        leverMove = Lever.GetComponent<LeverMove>();
        _initialPosition = transform.position;
    }

    void Update()
    {
        if (_isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, (_backToOrigin == true ? _initialPosition: _targetPosition), _speed * Time.deltaTime);
            CheckForExtremes();
        }
        else
        {
            CheckForInput();
        }
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && leverMove.LeverActivation == true)
        {
            _isMoving = true;
        }
    }

    private void CheckForExtremes()
    {
        if (transform.position == _targetPosition)
        {
            _backToOrigin = true;
            _isMoving = false;
        }
        else if (transform.position == _initialPosition)
        {
            _backToOrigin = false;
            _isMoving = false;
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
