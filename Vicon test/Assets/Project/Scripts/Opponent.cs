using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : fencer
{


    private void OnTriggerEnter(Collider other)
    {
        // if hit by player signal to gameManager
        if (other.gameObject.CompareTag("playerSword"))
        {
            GameManager.gameManager.OpponentHit();
        }
    }

    void SetAttacking(bool attack) // call in animation event for when an attack is happening
    {
        attacking = attack;
        if (attacking == false && parried == true)
            parried = false;
    }

}
