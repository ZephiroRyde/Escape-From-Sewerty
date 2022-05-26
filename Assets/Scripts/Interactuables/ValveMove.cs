using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveMove : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform[] locations;
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;
    [SerializeField] private float _detectDistance;

    /*private void Update()
    {
        

        if(Vector3.Distance(transform.position,GameManager.GetInstance.GetPlayerController.ptransform) < _detectDistance)
        {

            if (GameManager.GetInstance.GetPlayerController._interacting)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    platform.position = Vector3.MoveTowards(platform.transform.position, locations[0].position, moveSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    platform.position = Vector3.MoveTowards(platform.transform.position, locations[1].position, moveSpeed * Time.deltaTime);
                }
            }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position,_detectDistance);
    }
}
