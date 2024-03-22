using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentModel : MonoBehaviour
{
    [SerializeField]
    Opponent opponent;

    
    public Transform swordHand;




    // assign to model (if changing just disable other then enable one)

    private void Start()
    {
        CheckForModel();
    }

    private void OnEnable()
    {
        CheckForModel();
    }

    void CheckForModel()
    {
        if (opponent.model == null)
        {
            opponent.model = this;
        }
    }
}
