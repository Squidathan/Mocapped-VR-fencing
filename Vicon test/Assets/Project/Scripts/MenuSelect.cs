using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerSword")
        {
            GameManager.gameManager.Menu();
           
        }

    }
}
