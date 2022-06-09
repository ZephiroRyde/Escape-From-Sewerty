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
    [SerializeField] private bool _moving = false;
    private void Start()
    {
        _positions[0] = transform.localPosition;
    }

    private void Update()
    {
        if (_pActivator._isActive)
        {
            _pActivator._isActive = false;
            switch (_actualmode)
            {
                case PlatformMode.leverMove:
                    if (_moving) return;
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
    }

    public void MoveNormal()
    {
        _moving = true;
        transform.DOLocalMove(_positions[_actualPosition], _moveTime).OnComplete(() => 
        {
            _moving = false;
            _actualPosition++;
            if(_actualPosition >= _positions.Length)
            {
                _actualPosition = 0;
            }
        });

        
    }
    private void MoveNext()
    {
        _actualPosition++;
        if (_actualPosition >= _positions.Length)
        {
            _actualPosition = _positions.Length -1;
            return;
        }
        _moving = true;
        transform.DOLocalMove(_positions[_actualPosition], _moveTime).OnComplete(() =>
        {
            _moving = false;

        });
    }
    private void MovePrevious()
    {
        _actualPosition--;
        if(_actualPosition < 0)
        {
            _actualPosition = 0;
            return;
        }
        _moving = true;
        transform.DOLocalMove(_positions[_actualPosition], _moveTime).OnComplete(() =>
        {
            _moving = false;

        });
    }
}
