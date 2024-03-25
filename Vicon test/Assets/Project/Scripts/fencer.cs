using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class fencer : MonoBehaviour
{
    public sabre sabre;

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
}
