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

    [Header("General")]
    public bool _isActive = false;
    private bool _canActivate = false;


    [Header("Collider Info:")]
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private Vector3 _colliderCenter = Vector3.zero;
    [SerializeField] private float _colliderRadius = 2.5f;
    [SerializeField] private bool _colliderIsTrigger = true;


    [Header("On/Off Light")]
    [SerializeField] private MeshRenderer _activatorMesh;
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;


    private void Awake()
    {
        InitializeComponents();
        _activatorMesh.materials[0] = _offMaterial;
    }

    private void Update()
    {
        if(_canActivate)
        {
            if (Input.GetKeyDown(KeyCode.E))
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

    public void SwapMaterial()
    {
        //cambiamos material al activar
        _activatorMesh.materials[0] = (_isActive) ? _onMaterial : _offMaterial;
        //print(_activatorMesh.materials[0]);

        var mats = _activatorMesh.materials;
        mats[0] = (_isActive) ? _onMaterial : _offMaterial;

        _activatorMesh.materials = mats;
    }

    public void InitializeComponents()
    {
        _collider = gameObject.AddComponent<SphereCollider>() as SphereCollider;
        _collider.center = _colliderCenter;
        _collider.radius = _colliderRadius;
        _collider.isTrigger = _colliderIsTrigger;

    }
}
