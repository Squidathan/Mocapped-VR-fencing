using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentKeepDiscCollider : MonoBehaviour
{
    [SerializeField]
    Transform hand;

    [SerializeField]
    KeepDistanceBox box;

    bool playerInCollider = false;
    int collidersInCollider = 0;

    private void FixedUpdate()
    {
        transform.position = hand.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered");
        if (other.CompareTag("playerHand"))
        {
            collidersInCollider++;
            if (playerInCollider == false)
            {
                playerInCollider = true;
                box.InCollider();
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("triggerExited");
        if (other.CompareTag("playerHand"))
        {
            collidersInCollider--;
            if (collidersInCollider == 0)
            {
                playerInCollider = false;
                box.OutOfCollider();
            }

        }

    }

}
