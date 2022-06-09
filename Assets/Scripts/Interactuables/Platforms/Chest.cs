using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestContents
    {
        cheese
    }

    [SerializeField] private ChestContents _actualContent;

    private void Update()
    {
        switch(_actualContent)
        {
            case ChestContents.cheese:
                CheeseContent();
                break;
        }
    }

    private void CheeseContent()
    {
        throw new NotImplementedException();
    }
}
