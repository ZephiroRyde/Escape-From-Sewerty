using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Meta : MonoBehaviour
{
    public AudioSource aS;
    public AudioSource musicAS;
    public GameObject panelVictoria;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            aS.Play();
            musicAS.Stop();
            panelVictoria.SetActive(true);
        }
    }
}
