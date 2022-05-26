using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSources")]

    [SerializeField] private AudioSource _musicAS;
    [SerializeField] private AudioSource _sFXAS;

    [Header("AudioClips")]

    [SerializeField] private AudioClip[] _levelMusicAC;
    [SerializeField] private AudioClip   _gameOverAC;
    [SerializeField] private AudioClip _onGoalAC;
    public void PlayGameOverAudio()
    {
        _musicAS.clip = _gameOverAC;
        _musicAS.Play();
    }
    public void PlayGoalAudio()
    {
        _musicAS.clip = _onGoalAC;
        _musicAS.Play();
    }
    public void StopLevelMusic()
    {
        _musicAS.Pause();
    }
}
