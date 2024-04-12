using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeepDiscCollider : MonoBehaviour
{

    [SerializeField]
    Transform hand;

    private void FixedUpdate()
    {
        transform.position = hand.position;
    }

   
}
