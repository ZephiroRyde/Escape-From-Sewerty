using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteCaida : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetPlayerController.MoveToLPG();
        }
    }
}
