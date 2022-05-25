




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    private CapsuleCollider _collider;

    private void Awake() 
    {
        _collider = GetComponent<CapsuleCollider>(); //Esto se puede cambiar
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            //GameManager.GetInstance.GetPlayerController.isGrounded = true;
            Debug.Log("Toco Suelo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //GameManager.GetInstance.GetPlayerController.isGrounded = false;
            Debug.Log("salio Suelo");
        }
    }

}
