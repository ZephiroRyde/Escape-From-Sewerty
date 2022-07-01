using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance { get; private set; }
    CinemachineImpulseSource impulseCam;
    private void Awake()
    {
        Instance = this;
        impulseCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineImpulseSource>();
    }

    public void Sustain(float SustainTime)
    {
        impulseCam.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = SustainTime;
    }

    public void Decay(float DecayTime)
    {
        impulseCam.m_ImpulseDefinition.m_TimeEnvelope.m_DecayTime = DecayTime;
    }

    public void Intensity(float intensity)
    {
        impulseCam.m_ImpulseDefinition.m_AmplitudeGain = intensity;
    }
    public void ShakeCamera()
    {   
        impulseCam.GenerateImpulse();
    }
}
