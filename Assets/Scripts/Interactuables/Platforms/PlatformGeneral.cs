using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformGeneral : MonoBehaviour
{
    public enum cameraMode
    {
        cooldown,
        trigger

    }
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

    [Header("Camera")]
    private bool _cameraOff = true;
    [SerializeField] private bool _activeCamera = false;
    [SerializeField] private float _cameraCD = 3;
    private float actualCD;
    [SerializeField] private GameObject _targetCameraGO;
    [SerializeField] private cameraMode _cameraActualMode = cameraMode.cooldown;

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
        actualCD = _cameraCD;
    }

    private void Update()
    {
        if(_activeCamera && !_cameraOff)
        {
            if(actualCD >= 0)
            {
                actualCD -= Time.deltaTime;
            }
            else 
            {
                DeactivateCam();
                _cameraOff = true;
            }
        }

        if (Active() && !_rotating)
        {

            StartCoroutine(DeactiveCoroutine());
            //Deactivate();
            switch (_actualmode)
            {
                case PlatformMode.leverMove:
                    Debug.Log("LeverMove");
                    if (_moving) return;
                    ActivateCam();
                    EventManager.OnActivateMechanism();
                    LeverMoveMode();
                    break;
                case PlatformMode.leverRot:
                    Debug.Log("LeverRot");
                    if (_rotating) return;
                    ActivateCam();
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

    private void DeactivateCam()
    {
        _targetCameraGO.SetActive(false);
    }

    private void ActivateCam()
    {
        if (!_activeCamera) return;

        _cameraOff = false;
        switch(_cameraActualMode)
        {

            case cameraMode.cooldown:
                _targetCameraGO.SetActive(true);
                actualCD = _cameraCD;                
                break;

        }
    }
    
    private void Deactivate()
    {
        foreach (PlatformActivator activator in _pActivator)
        {
            activator._isActive = false;
        }
    }

    IEnumerator DeactiveCoroutine()
    {
        yield return new WaitForSecondsRealtime(_moveTime/2);
        Deactivate();
        StopCoroutine(DeactiveCoroutine());
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
        transform.DORotate(rotDir, _moveTime).OnComplete(() => { _rotating = false; _rotationComplete = !_rotationComplete; DeactivateCam(); });
        
        
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
