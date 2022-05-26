using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : MonoBehaviour
{
    public GameObject DisplayLeverLeft;
    public GameObject DisplayLeverRight;
    public bool LeverActivation = false;
    private bool _leverCancel = false;
    [SerializeField] float _cooldown;
    [SerializeField] bool _isLeverLeft = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LeverActivation = !_leverCancel;
        }
    }
    private void Update()
    {
        if (LeverActivation == true && Input.GetKeyDown(KeyCode.E))
        {
            DisplayLeverLeft.SetActive(!_isLeverLeft);
            DisplayLeverRight.SetActive(_isLeverLeft);
            _isLeverLeft = !_isLeverLeft;
            _leverCancel = true;
            Invoke("SetBoolTrue", _cooldown);
        }
    }
    private void SetBoolTrue()
    {
        _leverCancel = false;
    }

    private void OnTriggerExit(Collider other)
    {
        LeverActivation = false;
    }

}
