using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Opponent : fencer
{




    [SerializeField]
    float parryImmunityTime;

    [NonSerialized]
    public opponentModel model;

    [NonSerialized]
    public OpponentSabre opponentSabre;


    // animation states
    public enum OpponentAnimState
    {
        onGuard,
        other
    }
    public OpponentAnimState opponentAnimState = OpponentAnimState.onGuard;

    // called by state-behaviours
    virtual public void OnOnGuard()
    {
        opponentAnimState = OpponentAnimState.onGuard;
    }
    virtual public void OnOther()
    {
        opponentAnimState = OpponentAnimState.other;
    }

    private void Start()
    {
        opponentSabre = (OpponentSabre)sabre;

        GameManager.gameManager.OnBladeClash += ClashOfBlades;

    }

    private void OnDestroy()
    {
        GameManager.gameManager.OnBladeClash -= ClashOfBlades;
    }


    void ClashOfBlades()
    {
        opponentSabre.audioSource.PlayOneShot(opponentSabre.parrySound);
        if (attacking == true) // get parried until end of animation
        {
            parried = true;
        }
        else // successful parry
        {
            StartCoroutine(parriedImmunity());
        }
    }

    

    public void SetAttacking(bool attack) // call in animation event for when an attack is happening
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

    protected void SetAnim(string anim)
    {
        //Debug.Log("anim");
        model.GetComponent<Animator>().SetTrigger(anim);
        opponentSabre.GetComponent<Animator>().SetTrigger(anim);
    }
}
