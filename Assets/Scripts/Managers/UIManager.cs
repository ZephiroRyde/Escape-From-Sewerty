using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerData _pdata;

    [Header("Texto Info")]
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image infoTextPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private TextMeshProUGUI _victoryText;

    [Header("Brightness Settings")]
    [SerializeField] private Slider _brightSlider;
    [SerializeField] private TMP_Dropdown _resolutionDropDown;
    private float _actualBright = 0.2f;

    [Header("Volume Settings")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private AudioMixerGroup _musicMixer;
    [SerializeField] private Slider _sFXSlider;
    [SerializeField] private AudioMixerGroup _sFXMixer;
    [Space]
    [SerializeField] private float _volumeMultiplier;
    [SerializeField] private float _defaultVolume = 0.5f;
    
    private void Start()
    {
        _pdata = GameManager.GetInstance.GetPlayerController.pData;
        _brightSlider.value =_actualBright;
        _musicSlider.value = _defaultVolume;
        _sFXSlider.value = _defaultVolume;
    }
    private void FixedUpdate()
    {
        if(_actualBright != _brightSlider.value)
        {
            GameManager.GetInstance.ConfigureBrightness(_brightSlider.value);
            _actualBright = _brightSlider.value;
        }
    }

    public void LoadText(string actualtext)
    {
        print("cargar texto");
        infoText.text = actualtext;
    }

    public void ExitText()
    {
        infoTextPanel.gameObject.SetActive(false);
    }

    public void OpenText()
    {
        infoTextPanel.gameObject.SetActive(true);
    }

    public void LoadVictoryPanel()
    {

        VictoryPanel.SetActive(true);
        _victoryText.text = "Felicidades!!, tan solo el 9,6% de los jugadores logran escapar Conseguiste " + _pdata.cheeseAmount + " de 2 quesos";
        
    }

    public void ApllyResolution()
    {
        switch(_resolutionDropDown.value)
        {
            case 0:
                Screen.SetResolution(1920,1080,true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(10240, 576, true);
                break;
        }
    }
    public void SetMusicVolume(float musicVolume) // poner el audio de la m�sica 
    {
        AudioListener.volume = musicVolume;
        _musicMixer.audioMixer.SetFloat("MusicVolumeExposed", Mathf.Log10(musicVolume) * _volumeMultiplier);
    }

    public void SetSFXVolume(float sfxVolume) // poner el audio de los sfx 
    {
        AudioListener.volume = sfxVolume;
        _sFXMixer.audioMixer.SetFloat("SFXVolumeExposed", Mathf.Log10(sfxVolume) * _volumeMultiplier);
    }
}
