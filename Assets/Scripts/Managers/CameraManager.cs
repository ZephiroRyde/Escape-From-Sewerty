using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private int _actualCamera = 0;
    public int _actualCam;
    private void Start()
    {
    }
    public void ActivateCam()
    {
        _cameras[_actualCamera].SetActive(false);
        _actualCamera = _actualCam;
        _cameras[_actualCamera].SetActive(true);
    }


}
