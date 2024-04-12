using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeepDistanceOpponent : Opponent
{
    [SerializeField]
    KeepDistance keepDistanceManager;

    

    public bool outOfBoundsForward = false;
    int collidersOutOfBoundsForward = 0;

    public bool outOfBoundsBackward = false;
    int collidersOutOfBoundBackward = 0;

    Array steps = Enum.GetValues(typeof(KeepDistance.StepAnim));
    KeepDistance.StepAnim step;

    


    // on animation end TriggerAnim()
    public override void OnOnGuard()
    {
        base.OnOnGuard();

        if (outOfBoundsForward)
        {
            step = KeepDistance.StepAnim.mediumStepBackward;
        }
        else if (outOfBoundsBackward)
        {
            step = KeepDistance.StepAnim.mediumStepForward;
        }
        else
        {
            step = (KeepDistance.StepAnim)UnityEngine.Random.Range(0, steps.Length);
        }

        SetAnim(step.ToString(), false);
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("forwardBound"))
        {
            collidersOutOfBoundsForward++;
            if (!outOfBoundsForward)
            {
                outOfBoundsForward = true;
            }
        }
        else if (other.CompareTag("backwardBound"))
        {
            
            collidersOutOfBoundBackward++;
            if (!outOfBoundsBackward)
            {
                outOfBoundsBackward = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("forwardBound"))
        {
            collidersOutOfBoundsForward--;
            if (collidersOutOfBoundsForward == 0)
            {
                outOfBoundsForward = false;
            }

        }
        else if (other.CompareTag("backwardBound"))
        {
            collidersOutOfBoundBackward--;
            if (collidersOutOfBoundBackward == 0)
            {
                outOfBoundsBackward = false;
            }
        }
    }
    

}
