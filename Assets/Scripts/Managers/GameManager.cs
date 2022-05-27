using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Components")]
    [SerializeField] private PlayerMovement _playerController;
    [SerializeField] private Camera _camera;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioManager _audioManager;


    private void Start()
    {
        EventManager.GoalEvent += OnGoal;
        EventManager.ActivateMechanism += OnActivateMechanism;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        if (_instance != this)
        {
            _instance = this;
        }

        EventManager.GoalEvent -= OnGoal;
        EventManager.ActivateMechanism -= OnActivateMechanism;
    }
    //---------------------------------------------------------------------------------------//
    public static GameManager GetInstance
    {
        get { return _instance; }
    }
    public PlayerMovement GetPlayerController
    {
        get { return _playerController; }
    }

    public AudioManager GetAudioManager
    {
        get { return _audioManager; }
    }
    public UIManager GetUIManager
    {
        get { return _uiManager; }
    }
    public Camera GetCamera
    {
        get { return _camera; }
    }

    //---------------------------------------------------------------------------------------//
    public void ResetScene()
    {
        SceneManager.LoadScene("PruebasPiero");
    }

    public void OnGameOver()
    {
        _audioManager.PlayGameOverAudio();

    }

    public void OnGoal()
    {
        _audioManager.StopLevelMusic();
        _audioManager.PlayGoalAudio();
        _uiManager.LoadVictoryPanel();
    }

    public void OnActivateMechanism()
    {
        _audioManager.ActivateMechanismAudio();
    }
}
