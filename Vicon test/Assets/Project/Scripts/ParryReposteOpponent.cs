using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParryReposteOpponent : Opponent
{
    [SerializeField]
    ParryReposte parryReposteManager;

    [SerializeField]
    float loopAnimDelay = 5;

    enum AttackAnimation
    {
        lungeHead,
        lungeChest,
        lungeFlank
    }
    AttackAnimation attackAnimation = AttackAnimation.lungeHead;

    Array attacks = Enum.GetValues(typeof(AttackAnimation));

    IEnumerator TriggerAnim()
    {
            //Debug.Log("play anim");
            yield return new WaitForSeconds(loopAnimDelay);
            SetAnim(attackAnimation.ToString(), true);
    }




    public override void OnOnGuard()
    {
        base.OnOnGuard();

        attackAnimation = (AttackAnimation)UnityEngine.Random.Range(0, attacks.Length);
        StartCoroutine(TriggerAnim());
    }




    
}
