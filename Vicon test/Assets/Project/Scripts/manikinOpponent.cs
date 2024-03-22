using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manikinOpponent : Opponent
{
    [SerializeField]
    StaticManikin manikinActivityManager;

    [SerializeField]
    float loopAnimDelay = 5;

    private void OnEnable()
    {
        //StartCoroutine(TriggerAnim());
    }

    

    IEnumerator TriggerAnim()
    {
        if (manikinActivityManager.manikinAnimation != StaticManikin.ManikinAnimation.onGuard)
        {
            //Debug.Log("play anim");
            yield return new WaitForSeconds(loopAnimDelay);
            SetAnim(manikinActivityManager.manikinAnimation.ToString());
        }
        
    }


    // on animation end TriggerAnim()
    public override void OnOnGuard()
    {
        base.OnOnGuard();
        //Debug.Log("stuff");
        StartCoroutine(TriggerAnim());
    }
}
