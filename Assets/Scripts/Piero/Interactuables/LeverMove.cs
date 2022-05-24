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
    [SerializeField] bool _leftLever = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && _leverCancel == false)
        {
            LeverActivation = true;
        }
        else if (other.gameObject.tag == "Player" && _leverCancel == true)
        {
            LeverActivation = false;
        }
    }
    private void Update()
    {
        if (LeverActivation == true && Input.GetKeyDown(KeyCode.E))
        {
            if (_leftLever == true)
            {
                DisplayLeverLeft.SetActive(false);
                DisplayLeverRight.SetActive(true);
                _leftLever = false;
            }
            else if (_leftLever == false)
            {
                DisplayLeverRight.SetActive(false);
                DisplayLeverLeft.SetActive(true);
                _leftLever = true;
            }
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
