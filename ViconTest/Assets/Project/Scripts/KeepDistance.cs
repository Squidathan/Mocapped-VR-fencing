using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : Activity
{
    //Have only one StaticManikin instance available everywhere
    public static KeepDistance keepDistance;
    private void Awake()
    {
        keepDistance = this;
    }



    public override void ResetSettings()
    {
        
    }

    public override void ResetActivity()
    {
        
    }
}
