using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private int _actualCamera = 0;

    private void Start()
    {
        _cameras[0].SetActive(true);
    }
    public void ActivateCam(int camNum)
    {
        _cameras[_actualCamera].SetActive(false);
        _actualCamera = camNum;
        _cameras[_actualCamera].SetActive(true);
    }
}
