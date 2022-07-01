using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("General")]
    public string playerName = "Default";
    public int cheeseAmount = 0;
    public Vector3 pSaveposition;
    public Vector3 defaulyPosition;
    public bool normalDir;
    public int actualCam = 0;
}
