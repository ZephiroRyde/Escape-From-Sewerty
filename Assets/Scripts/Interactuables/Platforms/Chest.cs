using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Chest : MonoBehaviour
{
    public enum ChestContents
    {
        cheese
    }

    [SerializeField] private ChestContents _actualContent;
    [SerializeField] private bool _active = false;
    [SerializeField] private bool _canActive = false;

    [Header("Collider Info:")]
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private Vector3 _colliderCenter = Vector3.zero;
    [SerializeField] private float _colliderRadius = 2.5f;
    [SerializeField] private bool _colliderIsTrigger = true;

    [Header("LightInfo:")]
    [SerializeField] private float _lightDefaultIntensity = 15;
    [SerializeField] private float _lightRange = 2.75f;
    [SerializeField] private Light _light;

    [SerializeField] private GameObject _miniJuego;
    [SerializeField] private Animator _cheeseAnim;

    private void Awake()
    {
        InitializeComponents();
        
    }
    private void Update()
    {
        switch(_actualContent)
        {
            case ChestContents.cheese:
                CheeseContent();
                break;
        }
        if(_canActive && !_active)
        {
            _light.intensity = _lightDefaultIntensity;
        }
        else
        {
            _light.intensity = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canActive = false;
        }
    }

    private void CheeseContent()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canActive)
        {
            if(_active)
            {
                
                return;
            }
            _active = true;
            _miniJuego.SetActive(true);
            //GameManager.GetInstance.GetPlayerController.pData.cheeseAmount++;
            //cambiar a modelo abierto
            _cheeseAnim.SetBool("ActiveCheese",true);
        }
        
    }
    public void InitializeComponents()
    {
        _collider = gameObject.AddComponent<SphereCollider>() as SphereCollider;
        _collider.center = _colliderCenter;
        _collider.radius = _colliderRadius;
        _collider.isTrigger = _colliderIsTrigger;

        _light = gameObject.AddComponent<Light>() as Light;
        _light.type = LightType.Point;
        _light.range = _lightRange;
        _light.intensity = 0;
    }
}
