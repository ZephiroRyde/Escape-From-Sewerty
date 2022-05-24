using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMostrarTexto : MonoBehaviour
{
    [SerializeField] private string _actualText;




    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetUIManager.LoadText(_actualText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetUIManager.ExitText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance.GetUIManager.OpenText();
        }
    }
}
