using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveMove : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform[] locations;
    [SerializeField] private GameObject _light;
    [SerializeField] private bool _detectPlayer;

    private void Update()
    {
        if (_detectPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("interact");
                GameManager.GetInstance.GetPlayerController.Interact();
            }

            if (GameManager.GetInstance.GetPlayerController.currentState == PlayerMovement.PlayerState.Interacting)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    platform.position = Vector3.MoveTowards(platform.transform.position, locations[0].position, moveSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    platform.position = Vector3.MoveTowards(platform.transform.position, locations[1].position, moveSpeed * Time.deltaTime);
                }
            }
        }
        





    }
        
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _light.SetActive(true);
            _detectPlayer = true;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _detectPlayer = false;
            _light.SetActive(false);
        }
    }

}
