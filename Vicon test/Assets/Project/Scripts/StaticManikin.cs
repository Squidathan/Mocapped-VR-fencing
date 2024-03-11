using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticManikin : Activity
{
    //Have only one StaticManikin instance available everywhere
    public static StaticManikin staticManikin;
    private void Awake()
    {
        staticManikin = this;
    }


    
   


    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.OnStaticManikin += EnableStaticManikin;

        // disable the activity if main menu selected
        GameManager.gameManager.onMenu += BackToMainMenu;
    }
    private void OnDestroy()
    {
        // Unsubscriptions
        GameManager.gameManager.OnStaticManikin -= EnableStaticManikin;
        GameManager.gameManager.onMenu -= BackToMainMenu;
    }

    // Called when activity selected
    void EnableStaticManikin()
    {
        settingsMenu.SetActive(true);
    }


    public override void ResetActivity()
    {
        
    }

    public override void ResetSettings()
    {
        
    }

}