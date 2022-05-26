using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ValveRotation : MonoBehaviour
{

    [SerializeField] private float _rotateDuration;
    [SerializeField] private Transform platform;
    [SerializeField] private float _maxRot, _minRot;
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;
    [SerializeField] private float _detectDistance;

    [SerializeField] private bool isRot = false;

    /*private void Update()
    {
        if (GameManager.GetInstance.GetPlayerController._interacting)
        {
            if (Input.GetKey(KeyCode.A))
            {
                RotatePlatform(true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
<<<<<<< Updated upstream:Assets/Scripts/Interactuables/ValveRotation.cs
                RotatePlatform(false);
=======
                if(platform.rotation.x <= _maxRot)
                {
                    Debug.Log("rota d");
                    platform.eulerAngles += new Vector3(_rotateSpeed * Time.deltaTime , 0f, 0f);
                }
>>>>>>> Stashed changes:Assets/Scripts/Piero/Interactuables/ValveRotation.cs
                
            }
            
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                platform.DOPause();
                isRot = false;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                platform.DOPlay();
                isRot = true;
            }
        }

        if (Vector3.Distance(transform.position, GameManager.GetInstance.GetPlayerController.ptransform) < _detectDistance)
        {
            _selfMesh.material = _materials[1];

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.GetInstance.GetPlayerController.Interact();
            }
        }
        else
        {
            _selfMesh.material = _materials[0];
        }
    }*/

    public void RotatePlatform(bool rotateLeft = true)
    {
        if (isRot) return;

        Vector3 rot = Vector3.zero;

        Debug.Log("entra a rotate");

        isRot = true;

        if(rotateLeft)
        {
            rot.x = _minRot;
        }
        else
        {
            rot.x = _maxRot;
        }
        

        platform.DORotate(rot, _rotateDuration).OnComplete(() => { isRot = false; });
            

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _detectDistance);
    }
}
