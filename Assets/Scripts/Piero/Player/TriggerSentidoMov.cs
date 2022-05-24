using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSentidoMov : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetPlayerController.ChangeDirection();
            GameManager.GetInstance.GetPlayerController.MoveTo(transform.position);
        }
    }
}
