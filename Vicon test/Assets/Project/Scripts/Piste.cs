using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piste : MonoBehaviour
{
    [SerializeField]
    Activity activity;

    bool playerInPiste = false;
    int collidersInCollider = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("playerFoot"))
        {
            collidersInCollider++;

            if (playerInPiste == false)
            {
                playerInPiste = true;
                PlayActivity();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("playerFoot"))
        {
            collidersInCollider--;
            if (collidersInCollider == 0)
            {
                PauseActivity();
                playerInPiste = false;
            }

        }
    }


    public void PauseActivity()
    {

    }


    public void PlayActivity()
    {

    }
}
