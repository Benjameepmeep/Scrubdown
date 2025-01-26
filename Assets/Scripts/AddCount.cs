using System;
using UnityEngine;

public class AddCount : MonoBehaviour
{
    private void Start()
    {
        ObjectCouinter.objectCounter++;
    }

    private void OnDestroy()
    {
        ObjectCouinter.objectCounter--;
    }
}
