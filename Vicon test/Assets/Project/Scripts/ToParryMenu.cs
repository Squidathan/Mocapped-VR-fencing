using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToParryMenu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ParryReposte.parryReposte.ToActivityMenu();
    }
}
