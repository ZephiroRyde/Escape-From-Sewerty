using UnityEngine;
using UnityEngine.Animations;
public class PlayerMovement : MonoBehaviour
{
    public PlayerData pData;
    public enum PlayerState
    {
        Idle,
        Walking,
        Runing,
        Jumping,
        Interacting,
        Crouching,
        climbing
    }

    [Header("State")]
    public PlayerState currentState = PlayerState.Idle;

    [Header("Movement")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _runSpeed = 8;
    private float _movementSpeed = 5;

    private float _horizontal;
    private float _vertical;
    private bool _normalDir = true;

    [SerializeField] private Transform _model;
    [SerializeField] private float _rotationSpeed = 15;

    [Header("Character Controller")]
    [SerializeField] private float normalColliderHeight = 1.6f;
    [SerializeField] private float crounchColliderHeight = 1;
    [SerializeField] private Vector3 normalCharacterCenter = new Vector3(0,0.004f,0);
    [SerializeField] private Vector3 crounchCharacterCenter = new Vector3(0, -0.2f, 0);

    private CharacterController _charController;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight = 3;

    [Header("Gravity")]
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private float _fallGravityValue = -10f;

    [SerializeField] private Animator _pAnimator;
    
    private Vector3 _movement;
    private bool _isGrounded = false;
    private bool _wasGrounded = false;

    [Header("Interact")]
    private bool _interacting = false;

    [Header("Limits")]
    private Vector3 _lastPlaceGround;
    private void Awake() 
    {
        pData.cheeseAmount = 0;
        _charController = GetComponent<CharacterController>();
        
    }
    private void Start()
    {
        LoadPlayerPosition();
    }

    private void Update() 
    {

        switch(currentState)  
        {
            case PlayerState.Walking:
                _pAnimator.SetBool("Walk", true);
                _pAnimator.SetBool("Idle", false);
                break;
            case PlayerState.Runing:
                break;
            case PlayerState.climbing:
                break;
            case PlayerState.Jumping:
                break;
            case PlayerState.Interacting:
                break;
            case PlayerState.Idle:
                _pAnimator.SetBool("Walk", false);
                _pAnimator.SetBool("Idle", true);
                break;
            case PlayerState.Crouching:
                break;
        }

        _horizontal = Input.GetAxis("Horizontal");
        _vertical   = Input.GetAxis("Vertical");

        _isGrounded = _charController.isGrounded;
        if(_isGrounded)
        {
            if (_wasGrounded == false)
            {
                GameManager.GetInstance.OnPlayerLanded();
            }
            _lastPlaceGround = transform.position;
        }
        _wasGrounded = _isGrounded;

        if(currentState != PlayerState.Interacting)
        {
            Movement();
            HandleJump();
            HandleCrouch();
        }
        
        if(_horizontal == 0 && _vertical == 0 && currentState != PlayerState.Interacting && currentState != PlayerState.climbing)
        {
            currentState = PlayerState.Idle;
        }

        HandleGravity();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //----------------------------------------------------------------------------------------//

    private void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
        if (other.CompareTag("Wood"))
        {
            currentState = PlayerState.climbing;
            _isGrounded = false;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            currentState = PlayerState.Idle;
        }
        _isGrounded = false;
    }

    //----------------------------------------------------------------------------------------//

    
    public void HandleCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentState = PlayerState.Crouching;
            _charController.center = crounchCharacterCenter;
            _charController.height = crounchColliderHeight;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            currentState = PlayerState.Idle;
            _charController.center = normalCharacterCenter;
            _charController.height = normalColliderHeight;
        }
    }
    private void HandleJump()
    {
        if (!_isGrounded) return;

        if (Input.GetButtonDown("Jump")) 
        {
            _movement.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            GameManager.GetInstance.OnPlayerJumped();
        }

        if (Input.GetButtonUp("Jump") && _movement.y > 0) 
        {
            _movement.y *= 0.5f;
        }
    }

    private void Movement()
    {
        if(currentState == PlayerState.climbing)
        {
            _movement.y = _vertical * _movementSpeed;
        }


        //controlamos si corre o camina
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(currentState != PlayerState.climbing)
            {
                currentState = PlayerState.Runing;
            }
            
            _movementSpeed = _runSpeed;
        }
        else
        {
            if (currentState != PlayerState.climbing)
            {
                currentState = PlayerState.Walking;
            }
            _movementSpeed = _speed;
        }

        if(_normalDir)
        {
            _movement.z = _horizontal * _movementSpeed; //mover
            _movement.x = 0;
        }
        else
        {
            _movement.x = -_horizontal * _movementSpeed;
            _movement.z = 0;
        }

        Vector3 RoteDirection = new Vector3(_charController.velocity.x, 0, _charController.velocity.z);

        _model.forward = Vector3.Slerp(_model.forward, RoteDirection , Time.deltaTime * _rotationSpeed); //rotaci�n del modelo


    }
    private void HandleGravity()
    {
        if(currentState != PlayerState.climbing) //si no toca madera
        {
            if(!_isGrounded)
            {
               _movement.y += GetGravity() * Time.deltaTime;
            }
            
            
        }
        _charController.Move(_movement * Time.deltaTime); //movimiento

    }

    public void SavePointTeleport()
    {
        transform.position = pData.pSaveposition;
        
    }
    private float GetGravity()
    {
        float value = _gravityValue;

        if (!_isGrounded && _movement.y < 0)
            value = _fallGravityValue;

        return value;
    }

    public void ChangeDirection()
    {
        _normalDir = !_normalDir;

    }
    public void MoveToLPG()
    {
        transform.position = _lastPlaceGround + new Vector3(0, 1, 0);
    }

    public void MoveTo(Vector3 newPosition)
    {
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
    public void Interact()
    {
        if(currentState == PlayerState.Interacting)
        {
            currentState = PlayerState.Idle;
        }
        else
        {
            currentState = PlayerState.Interacting;
            _movement = Vector3.zero;
        }
        
    }

    public void SavePlayerPosition()
    {
        pData.pSaveposition = transform.position;
        pData.normalDir = _normalDir;
    }

    public void LoadPlayerPosition()
    {
        transform.position = pData.pSaveposition;
        _normalDir = pData.normalDir;
    }
}
