using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticManikinSelect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerSword")
        {
            GameManager.gameManager.StaticManikin();
            //Debug.Log("recognised");
        }
        //Debug.Log("hit");
    }
}
