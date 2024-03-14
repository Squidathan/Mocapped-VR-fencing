using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnHitStaticCollider : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(hitSound);
        Debug.Log("sound");
    }

    
}
