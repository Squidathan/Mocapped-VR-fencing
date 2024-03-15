using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKeepDistance : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KeepDistance.keepDistance.BeginActivity();
    }
}
