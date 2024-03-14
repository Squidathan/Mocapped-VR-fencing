using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToKeepDistanceMenu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KeepDistance.keepDistance.ToActivityMenu();
    }
}
