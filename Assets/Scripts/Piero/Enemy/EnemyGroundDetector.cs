using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundDetector : MonoBehaviour
{

    private Enemy01 _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = gameObject.GetComponentInParent<Enemy01>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            _enemyController.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _enemyController.isGrounded = false;
        }
    }
}
