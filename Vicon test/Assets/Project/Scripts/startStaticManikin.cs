using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startStaticManikin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StaticManikin.staticManikin.BeginActivity();
    }
}
