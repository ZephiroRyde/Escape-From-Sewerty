using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [TextArea(1, 8)]
    [SerializeField] private string Notas;


    //datos publicos generales
    public Vector3                                                   ptransform;

    [Header("Movimiento")]

    private float                                                    _horizontal;
    private float                                                    _vertical;

    [SerializeField] private float                                   _speed = 5;
    [SerializeField] private float                                   _runSpeed = 8;
    [SerializeField] private float                                   _jumpForce = 6;

    private float                                                    _movementSpeed;
    private Vector3                                                  _currentMovementDir;
    
    private bool                                                     _isCrounch;
    private bool                                                     _onWood = false;
    private bool                                                     _normalDir = true;
    private Vector3                                                  _lastPlaceGround = Vector3.zero;

    [Header("Interactuar")]

    public bool                                                      _interacting = false;



    [SerializeField] private Transform                               _model;
    [SerializeField] private float                                   _rotationSpeed = 15;
    private Animator                                                 _animator;
    private Rigidbody                                                _rb;


    [Header("Self Colliders")]
    [SerializeField] private CapsuleCollider                          _defaultCollider;
    [SerializeField] private CapsuleCollider                          _crounchCollider;

    [Header("Ground Detect")]
    [SerializeField] private bool                                     _isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        InitializeComponents(); //por ahora voy a llamar a esto porque sino el player no salta xd
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _defaultCollider.enabled = false;
            _crounchCollider.enabled = true;
            _isCrounch = true;
        }
        else
        {
            _defaultCollider.enabled = true;
            _crounchCollider.enabled = false;
            _isCrounch = false;

        }


        if (!_interacting)
        {
            Movement();
        }

        ptransform = transform.position;

        if (_isGrounded)
        {
            _lastPlaceGround = transform.position;
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
        if (other.CompareTag("Wood"))
        {
            _onWood = true;
            _rb.useGravity = false;
            _isGrounded = false;
        }

        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            _onWood = false;
            _rb.useGravity = true;
        }
        _isGrounded = false;
    }
    public void InitializeComponents()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>(); //Como esto estaría solo en el modelo, accedemos a él mediante el hijo
    }

    public void Movement()
    {
        
            //controlamos si corre o camina
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _movementSpeed = _runSpeed;
            }
            else
            {
                _movementSpeed = _speed;
            }
        
        

        //cargamos la direccion en la que se mueve el jugador
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if (_normalDir)
        {
            if (!_onWood)
            {
                _currentMovementDir = new Vector3(0, 0, _horizontal);
            }
            else
            {
                _currentMovementDir = new Vector3(0, _vertical, _horizontal);
            }

        }
        else
        {

            if (!_onWood)
            {
                _currentMovementDir = new Vector3(-_horizontal, _vertical, 0);
            }
            else
            {
                _currentMovementDir = new Vector3(-_horizontal, _vertical, 0);
            }

        }

        transform.Translate(_currentMovementDir * _movementSpeed * Time.deltaTime);

        if (_currentMovementDir != Vector3.zero)
        {
            _model.forward = Vector3.Slerp(_model.forward, _currentMovementDir, Time.deltaTime * _rotationSpeed); //rotación del modelo
        }
    }

    public void Jump()
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
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
        _interacting = !_interacting;
    }

}

