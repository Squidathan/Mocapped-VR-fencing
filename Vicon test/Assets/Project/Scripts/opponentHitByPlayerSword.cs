using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentHitByPlayerSword : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerSword"))
        {
            audioSource.PlayOneShot(hitSound);
            GameManager.gameManager.OpponentHit();
        }

    }
}
