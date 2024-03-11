using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStaticManikinMenu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StaticManikin.staticManikin.ToActivityMenu();
    }
}
