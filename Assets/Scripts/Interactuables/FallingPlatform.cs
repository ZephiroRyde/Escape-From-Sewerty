using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private bool _somethingTouch = false;
    private bool _falling = false;
    private Vector3 _initialPosition;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _amount = 0.01f;
    [SerializeField] private float _timeUntilFall = 1f;
    [SerializeField] private float _timeUntilDeactivation = 2f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _platform;

    private void Awake()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        _initialPosition = _platform.transform.position;
    }
    private void Update()
    {

        if (_falling == false && _somethingTouch == true)
        {
            _platform.transform.position = _initialPosition;
            _initialPosition.x += Mathf.Sin(Time.fixedTime * _speed) * _amount;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        _somethingTouch = true;
        Invoke("Fall", _timeUntilFall);
    }
    void Fall()
    {
        _falling = true;
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        Invoke("SetActiveObjectsFalse", _timeUntilDeactivation);
    }
    void SetActiveObjectsFalse()
    {
        gameObject.SetActive(false);
        _platform.SetActive(false);
    }
}