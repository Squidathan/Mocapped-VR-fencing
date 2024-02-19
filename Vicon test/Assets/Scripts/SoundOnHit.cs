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
        audioSource.PlayOneShot(hitSound);
        Debug.Log("sound");
    }
}
