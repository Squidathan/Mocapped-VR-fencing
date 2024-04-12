using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentModel : MonoBehaviour
{
    [SerializeField]
    Opponent opponent;

    [SerializeField]
    Transform startTransform;

    public Transform swordHand;


    // assign to model (if changing just disable other then enable one)

    private void Start()
    {
        CheckForModel();
    }

    private void OnEnable()
    {
        CheckForModel();
        transform.position = startTransform.position;
    }

    void CheckForModel()
    {
        if (opponent.model == null)
        {
            opponent.model = this;
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startTransform.position.z);
        
    }
}
