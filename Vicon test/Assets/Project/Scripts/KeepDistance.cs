using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : Activity
{
    

    [SerializeField]
    GameObject opponent;

    public enum StepAnim
    {
        mediumStepForward,
        mediumStepBackward
    }



    public override void ResetSettings()
    {
        
    }

    public override void ResetActivity()
    {
        
    }




    // menu navigation

    //Have only one StaticManikin instance available everywhere
    public static KeepDistance keepDistance;
    private void Awake()
    {
        keepDistance = this;
    }


    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.OnKeepDistance += EnableKeepDistance;

        // disable the activity if main menu selected
        GameManager.gameManager.onMenu += BackToMainMenu;
    }
    private void OnDestroy()
    {
        // Unsubscriptions
        GameManager.gameManager.OnKeepDistance -= EnableKeepDistance;
        GameManager.gameManager.onMenu -= BackToMainMenu;
    }
    
    // Called when activity selected
    void EnableKeepDistance()
    {
        settingsMenu.SetActive(true);
    }
}
