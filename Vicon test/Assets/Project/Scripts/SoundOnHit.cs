using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;

    [SerializeField]
    AudioClip playerHitSound;

    [SerializeField]
    Opponent opponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerSword"))
        {
            GameManager.gameManager.BladeClash();
        }
        if (other.CompareTag("Player"))
        {
            GameManager.gameManager.PlayerHit();
        }
    }
}
