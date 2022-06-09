using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public enum ActivatorMode
    {
        valve,
        lever
    }
    [SerializeField] private ActivatorMode _actualMode;

    public bool _isActive = false;
    private bool _canActivate = false;

    private void Update()
    {
        if(_canActivate)
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (_actualMode)
                {
                    case ActivatorMode.valve:
                        ValveActivator();
                        break;

                    case ActivatorMode.lever:
                        LeverActivator();
                        break;
                }
            }
            
            
            
        }
    }

    private void LeverActivator()
    {

        _isActive = !_isActive;
    }

    private void ValveActivator()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canActivate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canActivate = false;
        }
    }
}
