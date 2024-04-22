using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startStaticManikin : StartActivity
{
    public override void BeginActivity()
    {
        
        StaticManikin.staticManikin.BeginActivity();
    }
}
