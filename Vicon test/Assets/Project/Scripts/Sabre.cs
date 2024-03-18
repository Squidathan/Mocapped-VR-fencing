using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabre : MonoBehaviour
{

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip parrySound;

    [SerializeField]
    Opponent opponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerSword"))
        {
            GameManager.gameManager.BladeClash();
        }
        else if (other.CompareTag("Player"))
        {
            if (opponent.parried == false)
            {
                GameManager.gameManager.PlayerHit();
                
            }
        }
    }
}
