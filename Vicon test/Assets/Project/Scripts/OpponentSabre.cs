using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSabre : sabre
{

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip parrySound;

    [SerializeField]
    Opponent opponent;

    public bool holding = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerSword"))
        {
            GameManager.gameManager.BladeClash();
            //Debug.Log("playersword hit opponent sabre");
        }
        else if (other.CompareTag("Player"))
        {
            if (opponent.parried == false)
            {
                GameManager.gameManager.PlayerHit();
                
            }
        }
    }

    private void FixedUpdate()
    {
        if (opponent.model.swordHand.position != null && holding == true)
        {
            transform.position = opponent.model.swordHand.position;
        }
    }


    // animation event
    void SetOpponentAttacking(int attacking)
    {
        bool attack;
        if (attacking == 0)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
        opponent.SetAttacking(attack);
    }


    // assign to opponent (if changing just disable other then enable one)
    private void Start()
    {
        CheckForSabre();
    }

    private void OnEnable()
    {
        CheckForSabre();
    }

    void CheckForSabre()
    {
        if (opponent.opponentSabre == null)
        {
            opponent.opponentSabre = this;
        }
    }


}
