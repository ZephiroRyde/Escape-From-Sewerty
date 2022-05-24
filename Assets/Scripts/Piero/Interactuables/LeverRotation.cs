using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotation : MonoBehaviour
{
    public GameObject Lever;
    LeverMove leverMove;
    [SerializeField] float _rotationAmount = 90f;
    [SerializeField] float _rotationSpeed = 30;
    [SerializeField] bool _isRotated = true;

    private bool _isRotating;
    private float _currentRotationAmount;
    private int _direction;
   
    private void Awake()
    {
        leverMove = Lever.GetComponent<LeverMove>();
    }

    void Update()
    {
        if (leverMove.LeverActivation == true && Input.GetKeyDown(KeyCode.E))
        {
            TriggerRotation();           
        }

        if (!_isRotating)
        {
            return;
        }

        if (_currentRotationAmount < _rotationAmount)
        {
            float rot = Time.deltaTime * _rotationSpeed;
            _currentRotationAmount += rot;
            transform.Rotate(new Vector3(0, 0, rot * _direction));
        }
        else
        {
            _isRotating = false;
        }
    }

    public void TriggerRotation()
    {
        _isRotated = !_isRotated;
        _direction = _isRotated ? -1 : 1;
        _currentRotationAmount = 0;
        _isRotating = true;
    }
}
