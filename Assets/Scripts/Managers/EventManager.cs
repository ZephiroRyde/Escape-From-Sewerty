using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
//  TYPE:                                                             NAME:
    private UIManager                                                 _uiManager;
    private AudioManager                                              _audioManager;
    private void Start()
    {
       _audioManager = GameManager.GetInstance.GetAudioManager;
       _uiManager    = GameManager.GetInstance.GetUIManager;
    }
    public static event UnityAction GameOverEvent;
    public void OnGameOver()
    {
        _audioManager.PlayGameOverAudio();
        
    }
}
