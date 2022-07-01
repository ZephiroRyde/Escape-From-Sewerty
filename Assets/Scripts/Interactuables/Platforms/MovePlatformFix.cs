using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformFix : MonoBehaviour
{
    [SerializeField]private Transform _playerTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerTransform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerTransform.SetParent(null);
    }
}
