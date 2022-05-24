using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject Lever;
    LeverMove leverMove;
    public Material[] material;
    Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        leverMove = Lever.GetComponent<LeverMove>();
    }
    private void Update()
    {
        if (leverMove.LeverActivation == true)
        {
            rend.sharedMaterial = material[1];
        }
        if (leverMove.LeverActivation == false)
        {
            rend.sharedMaterial = material[0];
        }
    }

}
