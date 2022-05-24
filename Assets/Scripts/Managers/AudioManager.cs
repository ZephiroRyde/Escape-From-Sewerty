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

    public void PlayGameOverAudio()
    {
        _musicAS.clip = _gameOverAC;
        _musicAS.Play();
    }
}
