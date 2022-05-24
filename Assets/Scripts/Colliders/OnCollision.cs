using UnityEngine;
using UnityEngine.Events;

public class OnCollision : MonoBehaviour
{
    public UnityEvent onCollisionEnter;
    public UnityEvent onCollisionExit;
    [SerializeField] private string otherTag = "Player";

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            onCollisionEnter?.Invoke();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            onCollisionExit?.Invoke();
        }
    }
}
