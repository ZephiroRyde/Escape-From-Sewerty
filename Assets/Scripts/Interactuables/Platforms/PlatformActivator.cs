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
    [SerializeField] private Light _light;


    [Header("Collider Info:")]
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private Vector3 _colliderCenter = Vector3.zero;
    [SerializeField] private float _colliderRadius = 2.5f;
    [SerializeField] private bool _colliderIsTrigger = true;

    [Header("LightInfo:")]
    [SerializeField] private float _lightDefaultIntensity = 15;
    [SerializeField] private float _lightRange = 2.75f;

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
            if(_light)
                _light.intensity = _lightDefaultIntensity;
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
        else
        {   if(_light)
                _light.intensity = 0;
        }
    }

    private void LeverActivator()
    {
        _isActive = !_isActive;
        _activatorMesh.materials[0] = (_isActive) ? _onMaterial : _offMaterial;
        print(_activatorMesh.materials[0]);

        var mats = _activatorMesh.materials;
        mats[0]= (_isActive) ? _onMaterial : _offMaterial; 

        _activatorMesh.materials = mats;

        // if(_activatorMesh.materials[0] == _offMaterial)
        // {
        //     _activatorMesh.materials[0] = _onMaterial;
        // }
        // else
        // {
        //     _activatorMesh.materials[0] = _offMaterial;
        // }
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


    public void InitializeComponents()
    {
        _collider = gameObject.AddComponent<SphereCollider>() as SphereCollider;
        _collider.center = _colliderCenter;
        _collider.radius = _colliderRadius;
        _collider.isTrigger = _colliderIsTrigger;

        // _light = gameObject.AddComponent<Light>() as Light;
        // _light.type = LightType.Point;
        // _light.range = _lightRange;
        // _light.intensity = 0;
    }
}
