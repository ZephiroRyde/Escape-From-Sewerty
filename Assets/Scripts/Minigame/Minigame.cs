using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    [SerializeField] private Transform _ping, _pong;
    [Range(0, 5)]
    [SerializeField] private float _speed = 1;
    [SerializeField] private bool _win = false;
    [SerializeField] private GameObject _miniJuego;
    void OnEnable()
    {
        if (_speed < 5)
        {
            _speed += 1;
        }
        GameManager.GetInstance.GetPlayerController.Interact();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            _win = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _win = false;
    }
    void Update()
    {

        float pingPong = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_ping.position, _pong.position, pingPong);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_win == true)
            {
                GameManager.GetInstance.GetPlayerController.pData.cheeseAmount++;
                Debug.Log("ganaste");
            }
            else if (_win == false)
            {
                GameManager.GetInstance.GetPlayerController.SavePointTeleport();
                Debug.Log("perdiste");
            }
            GameManager.GetInstance.GetPlayerController.Interact();
            _miniJuego.SetActive(false);
        }


    }
}
