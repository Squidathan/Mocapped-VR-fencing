using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class fencer : MonoBehaviour
{
    [System.NonSerialized]
    public bool attacking = false;

    [System.NonSerialized]
    public bool parried = false;

    [System.NonSerialized]
    public bool gotParry = false;

    [System.NonSerialized]
    public bool hit = false;

    [System.NonSerialized]
    public bool gotHit = false;

    [System.NonSerialized]
    public bool corpsACorps = false;



    /*
    public abstract void Parried();

    public abstract void GotParry();

    public abstract void HitOpponent();

    public abstract void GotHitByOpponent();

    public abstract void ClashOfBlades();

    public abstract void CorpsACorps();
    */

    
}
