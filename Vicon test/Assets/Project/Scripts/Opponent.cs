using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;

    [SerializeField]
    float timeOfImmunity = 1f;

    bool attacking = false;

    bool swordEnabled = true;

    Collider[] colliders;


    private void Start()
    {
        colliders = this.GetComponentsInChildren<Collider>();

        // subscribe to events
        GameManager.gameManager.OnOpponentHit += GotHit;
        GameManager.gameManager.OnBladeClash += BladeClash;
        GameManager.gameManager.OnPlayerHit += HitPlayer;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameManager.gameManager.OnOpponentHit -= GotHit;
        GameManager.gameManager.OnBladeClash -= BladeClash;
        GameManager.gameManager.OnPlayerHit -= HitPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if hit by player signal to gameManager
        if (other.gameObject.CompareTag("playerSword"))
        {
            GameManager.gameManager.OpponentHit();
        }
    }

    void GotHit()
    {
        audioSource.PlayOneShot(hitSound);
        TempDisableBodyCollider();
    }

    void BladeClash()
    {
        // got parried
        if (attacking == true)
        {
            // disable sword until attack anim is over
            SwordEnabled(false);
        }
        // got the parry
        else
        {
            // can't get hit in the body for a bit
            TempDisableBodyCollider();
        }
    }

    

    void SetAttacking(bool attack) // call in animation event for when an attack is happening
    {
        attacking = attack;
        if (attack == false && swordEnabled == false)
        {
            SwordEnabled(true);
        }
    }

    void HitPlayer()
    {

    }

















    // helper methods

    void SwordEnabled(bool enabled)
    {
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("sword"))
            {
                collider.enabled = enabled;
            }
        }
        swordEnabled = enabled;
    }

    IEnumerable TempDisableBodyCollider()
    {
        BodyCollidersEnabled(false);
        yield return new WaitForSeconds(timeOfImmunity);
        BodyCollidersEnabled(true);
    }

    void BodyCollidersEnabled(bool enabled)
    {
        foreach (Collider collider in colliders)
        {
            if (!collider.CompareTag("sword"))
            {
                collider.enabled = enabled;
            } 
        }
    }
}
