using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeepDistanceOpponent : Opponent
{
    [SerializeField]
    KeepDistance keepDistanceManager;

 

    Array steps = Enum.GetValues(typeof(KeepDistance.StepAnim));
    KeepDistance.StepAnim step;


    // on animation end TriggerAnim()
    public override void OnOnGuard()
    {
        base.OnOnGuard();

        step = (KeepDistance.StepAnim)UnityEngine.Random.Range(0, steps.Length);

        SetAnim(step.ToString());
    }


}
