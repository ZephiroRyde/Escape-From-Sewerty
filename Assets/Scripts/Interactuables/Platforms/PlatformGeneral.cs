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
        valveRot,
        pasiveRot

    }

    public enum PlatformMoveMode
    {
        normal,
        next,
        previous
    }

    public enum PlatformRotAxis
    {
        x,
        y,
        z
    }

    public enum PlatformRotDirection
    {
        left,
        right
    }


    [Header("General")]
    [SerializeField] PlatformActivator[] _pActivator;
    [SerializeField] private PlatformRotAxis _actualAxis;
    [SerializeField] private PlatformRotDirection _actualDirection;
    [SerializeField] private float _moveTime = 2;

    [Header("Opciones:")]
    [SerializeField] private PlatformMode _actualmode;

    [Header("Lever Move;")]
    [SerializeField] private PlatformMoveMode _actualMoveMode;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private int _actualPosition = 0;
    [SerializeField] private bool _moving = false;

    [Header("Lever Rotate")]
    [SerializeField] private float _normalRot;
    [SerializeField] private float _finalRot;
    [SerializeField] private bool _rotating = false;
    [SerializeField] private bool _rotationComplete = false;

    private void Start()
    {
        InitializeScript();
    }

    private void Update()
    {
        if (Active())
        {
            Deactivate();
            switch (_actualmode)
            {
                case PlatformMode.leverMove:
                    if (_moving) return;
                    EventManager.OnActivateMechanism();
                    LeverMoveMode();
                    break;
                case PlatformMode.leverRot:
                    if (_rotating) return;
                    EventManager.OnActivateMechanism();
                    LeverRotMode();
                    break;
                case PlatformMode.valveMove:
                    ValveMoveMode();
                    break;
                case PlatformMode.valveRot:
                    ValveRotMode();
                    break;
                case PlatformMode.pasiveRot:
                    PasiveRotMode();
                    break;
            }
        }
        
    }

    

    private void Deactivate()
    {
        foreach (PlatformActivator activator in _pActivator)
        {
            activator._isActive = false;
        }
    }

    private bool Active()
    {
        bool _active = false; 

        foreach(PlatformActivator activator in _pActivator)
        {
            if(activator._isActive)
            {
                _active =  true;
            }
        }

        return _active;
    }

    private void PasiveRotMode()
    {
        throw new NotImplementedException();
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
        Vector3 rotDir = Vector3.zero;
        switch (_actualAxis)
        {
            case PlatformRotAxis.x:
                if (_rotationComplete)
                {
                    rotDir.x = _normalRot;
                }
                else
                rotDir.x = _finalRot;
                break;
            case PlatformRotAxis.y:
                if (_rotationComplete)
                {
                    rotDir.y = _normalRot;
                }
                else
                    rotDir.y = _finalRot;
                break;
            case PlatformRotAxis.z:
                if (_rotationComplete)
                {
                    rotDir.z = _normalRot;
                }
                else
                    rotDir.z = _finalRot;
                break;
        }
        _rotating = true;
        transform.DORotate(rotDir, _moveTime).OnComplete(() => { _rotating = false; _rotationComplete = !_rotationComplete; });
        
        
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

    public void InitializeScript()
    {
        _positions[0] = transform.localPosition;
        
        switch(_actualDirection)
        {
            case PlatformRotDirection.left:
                _finalRot = -_finalRot;
                break;
            case PlatformRotDirection.right:
                _finalRot = MathF.Abs(_finalRot);
                break;

        }
    }
}
