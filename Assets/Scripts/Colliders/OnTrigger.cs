using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    [SerializeField] private string otherTag = "Player";

    public bool activado;
    void OnTriggerEnter(Collider other)
    {
        if (!activado) return;

        if (other.gameObject.CompareTag(otherTag))
        {
            onTriggerEnter?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!activado) return;

        if (other.gameObject.CompareTag(otherTag))
        {
            onTriggerExit?.Invoke();
        }
    }



    public static void Goal()
    {
        //aS.Play();                     AUDIO MANAGER
        //musicAS.Stop();                AUDIO MANAGER
        //panelVictoria.SetActive(true); UI MANAGER
    }
}
