using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectsRootMotionUpdate : MonoBehaviour
{
    [SerializeField]
    GameObject following;

    public void UpDateRootMotion()
    {
        this.gameObject.transform.position = following.gameObject.transform.position;
    }
}
