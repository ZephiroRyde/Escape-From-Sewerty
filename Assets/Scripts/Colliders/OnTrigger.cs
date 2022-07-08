using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class OnTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    //[SerializeField] private List<string> otherTag = new List<string>();

    [SerializeField] private string _otherTag = "Player";

    /// <summary>
    /// 0 - Player
    /// 1 - Ground
    /// 2 - Enemy
    /// 3 - Wood
    /// </summary>
    
   
    public bool activado;

    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (!activado) return;

        if (other.gameObject.CompareTag(_otherTag))
        {
            onTriggerEnter?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!activado) return;

        if (other.gameObject.CompareTag(_otherTag))
        {
            onTriggerExit?.Invoke();
        }
    }


    public void CameraActivate(int cameraNum)
    {
        GameManager.GetInstance.GetCameraManager._actualCam = cameraNum;
        GameManager.GetInstance.GetPlayerController.pData.actualCam = cameraNum;
        EventManager.OnChangeCamera();
    }
}
