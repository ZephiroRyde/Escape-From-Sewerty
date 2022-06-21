using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSources")]

    [SerializeField] private AudioSource _musicAS;
    [SerializeField] private AudioSource _sFXAS;
    [SerializeField] private AudioSource _playerAS;

    [Header("AudioClips")]

    [SerializeField] private AudioClip[] _levelMusicAC;
    [SerializeField] private AudioClip   _gameOverAC;
    [SerializeField] private AudioClip _onGoalAC;
    [SerializeField] private AudioClip _mechanismAC;
    [SerializeField] private AudioClip _playerJumpAC;
    [SerializeField] private AudioClip _playerLandAC;
    [SerializeField] private AudioClip _playerDeadAC;
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

    public void ActivateMechanismAudio()
    {
        _sFXAS.PlayOneShot(_mechanismAC);
    }

    public void PlayJumped()
    {
        if(_playerJumpAC == null)
        {
            return;
        }
        _playerAS.clip = _playerJumpAC;
        _playerAS.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        _playerAS.Play();
    }

    public void PlayLanded()
    {
        if (_playerLandAC == null)
        {
            return;
        }
        _playerAS.clip = _playerLandAC;
        _playerAS.Play();
    }

    public void PlayDied()
    {
        if (_playerDeadAC == null)
        {
            return;
        }
        _playerAS.clip = _playerDeadAC;
        _playerAS.Play();
        //prefiero no tocar esto aun
    }
}
