using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : fencer
{
    [SerializeField]
    float parryImmunityTime;

    

    void ClashOfBlades()
    {
        sabre.audioSource.PlayOneShot(sabre.parrySound);
        if (attacking == true) // get parried until end of animation
        {
            parried = true;
        }
        else // successful parry
        {
            StartCoroutine(parriedImmunity());
        }
    }

    

    void SetAttacking(bool attack) // call in animation event for when an attack is happening
    {
        attacking = attack;
        if (attacking == false && parried == true)
        {
            parried = false;
        }
    }

    // signal event if I get hit by sword or human
    private void OnTriggerEnter(Collider other)
    {
        // if hit by player signal to gameManager
        if (other.CompareTag("playerSword") && !gotParry)
        {
            
            GameManager.gameManager.OpponentHit();
        }
        else if (other.CompareTag("Player") && !gotParry)
        {
            GameManager.gameManager.CorpACorp();
        }
    }





    // helper functions
    IEnumerator parriedImmunity()
    {
        gotParry = true;
        yield return new WaitForSeconds(parryImmunityTime);
        gotParry = false;
    }
}
