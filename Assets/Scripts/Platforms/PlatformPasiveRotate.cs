using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformPasiveRotate : MonoBehaviour
{
    [SerializeField] private bool _positiveDir = true;
    [SerializeField] private float _rotateTime = 5;
    void Start()
    {
        if(_positiveDir)
        {
            transform.DORotate(new Vector3(0, 0, 360), _rotateTime, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, -360), _rotateTime, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }
        
    }
}
