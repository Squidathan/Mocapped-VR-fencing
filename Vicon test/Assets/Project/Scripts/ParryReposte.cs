using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryReposte : pointsActivity
{
    //settings
    public bool gamified = false;

    
    
    public override void ResetActivity()
    {
        
    }

    public override void ResetSettings()
    {
        
    }







    // menu navigation

    //Have only one StaticManikin instance available everywhere
    public static ParryReposte parryReposte;
    private void Awake()
    {
        parryReposte = this;
    }


    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.OnParryReposte += EnableParryReposte;

        // disable the activity if main menu selected
        GameManager.gameManager.onMenu += BackToMainMenu;
    }
    private void OnDestroy()
    {
        // Unsubscriptions
        GameManager.gameManager.OnParryReposte -= EnableParryReposte;
        GameManager.gameManager.onMenu -= BackToMainMenu;
    }

    // Called when activity selected
    void EnableParryReposte()
    {
        settingsMenu.SetActive(true);
    }
}
