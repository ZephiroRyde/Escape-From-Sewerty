using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LeverRotate : MonoBehaviour
{
    [Header("Platform Data")]
    [SerializeField] private Transform _platform;

    [Header("Rotate Parameters")]
    [SerializeField] private float _rotateDuration = 3;
    [SerializeField] private float _minRot = 0;
    [SerializeField] private float _maxRot = 90;
    [SerializeField] private bool _canInteract = false;
    [SerializeField] private bool _rotateX = true;
    [SerializeField] private bool _rotateLeft = true;
    [SerializeField] private bool _isRot = false;

    [Header("Render")]
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;

    private void Update()
    {
        if(_canInteract)
        {
            _selfMesh.material = _materials[1];
            if(Input.GetKeyDown(KeyCode.E) && !_isRot)
            {
                RotatePlatform();
                EventManager.OnActivateMechanism();
            }
        }
        else
        {
            _selfMesh.material = _materials[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = false;
        }
    }

    //----------------------------------------------------------------------------------//

    public void RotatePlatform()
    {
        Vector3 rot = Vector3.zero;
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

        if(_isRot)
        {
            _platform.DORotate(rot, _rotateDuration).OnComplete(() => { _isRot = false; _rotateLeft = !_rotateLeft; });
        }
        else
        {
            _platform.DORotate(rot, _rotateDuration).OnComplete(() => { _isRot = false; _rotateLeft = !_rotateLeft; });
        }    
        
    }


}
