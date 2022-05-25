using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _runSpeed = 8;
    private float _movementSpeed = 5;
    [Header("Jump")]
    [SerializeField] private float _jumpHeight = 3;

    [Header("Gravity")]
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private float _fallGravityValue = -10f;

    private CharacterController _charController;
    private Vector3 _movement;
    private bool _isGrounded = false;

    private void Awake() 
    {
        _charController = GetComponent<CharacterController>();    
    }

    private void Update() 
    {
        _isGrounded = _charController.isGrounded;

        Movement();
        HandleGravity();
        HandleJump();
    }

    private void HandleJump()
    {
        if (!_isGrounded) return;

        if (Input.GetButtonDown("Jump")) 
        {
            _movement.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        if (Input.GetButtonUp("Jump") && _movement.y > 0) 
        {
            _movement.y *= 0.5f;
        }
    }

    private void Movement()
    {
        _movement.z = Input.GetAxis("Horizontal") * _movementSpeed;
    }
    private void HandleGravity()
    {
        _movement.y += GetGravity() * Time.deltaTime;
        _charController.Move(_movement * Time.deltaTime);
    }

    private float GetGravity()
    {
        float value = _gravityValue;

        if (!_isGrounded && _movement.y < 0)
            value = _fallGravityValue;

        return value;
    }
}
