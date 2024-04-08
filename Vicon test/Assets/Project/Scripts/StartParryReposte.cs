using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParryReposte : StartActivity
{
    public override void BeginActivity()
    {
        ParryReposte.parryReposte.BeginActivity();
    }
}
