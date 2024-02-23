using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableOrDisableOnMenu : MonoBehaviour
{
    [SerializeField]
    GameObject activityEnableObject;

    [SerializeField]
    bool enable = true;

    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.onMenu += DisableActivity;
        
    }
    private void OnDestroy()
    {
        // Unsubscribe from nabling and disabling the objects if changing state
        GameManager.gameManager.onMenu -= DisableActivity;
    }

    // Called when activity selected
    void DisableActivity()
    {
        activityEnableObject.SetActive(enable);
    }
}
