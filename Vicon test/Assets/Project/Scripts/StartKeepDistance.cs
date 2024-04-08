using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKeepDistance : StartActivity
{
    public override void BeginActivity()
    {
        KeepDistance.keepDistance.BeginActivity();
    }
}
