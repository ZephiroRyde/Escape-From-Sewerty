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
    public static event UnityAction GoalEvent;
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
}
