using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
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
            GameManager.gameManager.BladeClash();
        }
        
    }
}
