using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformGeneral : MonoBehaviour
{
    public enum PlatformMode
    {        
        leverMove,
        leverRot,
        valveMove,
        valveRote

    }

    public enum PlatformMoveMode
    {
        normal,
        next,
        previous
    }

    [Header("General")]
    [SerializeField] PlatformActivator _pActivator;
    [SerializeField] private bool _xAxis;
    [SerializeField] private bool _rotateLeft;


    [Header("Opciones:")]
    [SerializeField] private PlatformMode _actualmode;

    [Header("LeverMove;")]
    [SerializeField] private PlatformMoveMode _actualMoveMode;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private int _actualPosition = 0;
    [SerializeField] private float _moveTime = 2;

    private void Start()
    {
        _positions[0] = transform.position;
    }

    private void Update()
    {
        if (_pActivator._isActive)
        {
            switch (_actualmode)
            {
                case PlatformMode.leverMove:
                    LeverMoveMode();
                    break;
                case PlatformMode.leverRot:
                    LeverRotMode();
                    break;
                case PlatformMode.valveMove:
                    ValveMoveMode();
                    break;
                case PlatformMode.valveRote:
                    ValveRotMode();
                    break;
            }
        }
        
    }

    private void ValveRotMode()
    {
        throw new NotImplementedException();
    }

    private void ValveMoveMode()
    {
        throw new NotImplementedException();
    }

    private void LeverRotMode()
    {
        throw new NotImplementedException();
    }

    private void LeverMoveMode()
    {        
        switch(_actualMoveMode)
        {
            case PlatformMoveMode.normal:
                MoveNormal();
                break;
            case PlatformMoveMode.next:
                MoveNext();
                break;
            case PlatformMoveMode.previous:
                MovePrevious();
                break;
        }
        if (_pActivator._isActive)
        {
            _pActivator._isActive = false;
        }
    }

    public void MoveNormal()
    {
        if (_actualPosition++ >= _positions.LongLength) //no funciona, como consigo el largo de un arreglo??
        {
            transform.DOLocalMove(_positions[_actualPosition++], _moveTime).OnComplete(() => { _actualPosition = _actualPosition++; });
        }
        else
        {
            transform.DOLocalMove(_positions[0], _moveTime).OnComplete(() => { _actualPosition = 0; });
        }
    }
    private void MoveNext()
    {
        if (_positions[_actualPosition++] != null)
        {
            transform.DOLocalMove(_positions[_actualPosition++], _moveTime).OnComplete(() => { _actualPosition = _actualPosition++; });
        }
        
    }
    private void MovePrevious()
    {
        if(_positions[_actualPosition--] != null)
        {
            transform.DOLocalMove(_positions[_actualPosition--], _moveTime).OnComplete(() => { _actualPosition = _actualPosition--; });
        }
        
    }

}
