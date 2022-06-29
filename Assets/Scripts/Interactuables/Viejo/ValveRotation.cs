using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ValveRotation : MonoBehaviour
{
    [Header("Platform Data")]
    [SerializeField] private Transform _platform;

    [Header("Rotate Parameters")]
    [SerializeField] private float _rotateDuration = 3;
    [SerializeField] private float _minRot = 0;
    [SerializeField] private float _maxRot = 90;
    [SerializeField] private bool _rotateX = true;
    [SerializeField] private bool _rotateLeft = true;
    [SerializeField] private bool _isRot = false;
    [SerializeField] private bool _detectPlayer = false;

    [Header("Others")]
    [SerializeField] private GameObject _light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_light)
                _light.SetActive(true);
            _detectPlayer = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _detectPlayer = false;
            if (_light)
                _light.SetActive(false);
        }
    }

    private void Update()
    {
        if (GameManager.GetInstance.GetPlayerController.currentState == PlayerMovement.PlayerState.Interacting && _detectPlayer)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _rotateLeft = true;
                RotatePlatform();
            }
            else if (Input.GetKey(KeyCode.D ) || Input.GetKey(KeyCode.RightArrow))
            {
                _rotateLeft = false;
                RotatePlatform();
                
            }
            
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _platform.DOPause();
                _isRot = false;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _platform.DOPlay();
                _isRot = true;
            }
        }

        if (_detectPlayer)
        {
            if (_light)
                _light.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.GetInstance.GetPlayerController.Interact();
            }
        }
        else
        {   if (_light)
                _light.SetActive(false);
        }
    }

    public void RotatePlatform()
    {
        if (_isRot) return;

        Vector3 rot = Vector3.zero;

        Debug.Log("entra a rotate");

        _isRot = true;

        if (_rotateX)
        {
            if (_rotateLeft)
            {
                rot.x = _minRot;
            }
            else
            {
                rot.x = _maxRot;
            }
        }
        else
        {
            if (_rotateLeft)
            {
                rot.z = _minRot;
            }
            else
            {
                rot.z = _maxRot;
            }
        }


        _platform.DORotate(rot, _rotateDuration).OnComplete(() => { _isRot = false; });
            

    }
}
