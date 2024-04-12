using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticManikin : Activity
{
    [SerializeField]
    Box box;


    // Settings
    public enum ManikinAnimation
    {
        onGuard,
        hitChest,
        hitHead,
        hitFlank,
        lungeChest,
        lungeHead,
        lungeFlank
    }
    public ManikinAnimation manikinAnimation = ManikinAnimation.onGuard;

    public override void ResetSettings()
    {
        manikinAnimation = ManikinAnimation.onGuard;
    }


    // what changes during activity

    // variables that need resetting after activity here



    // called when exiting activity
    public override void ResetActivity()
    {
        //box.ResetBox();
    }

    







    // menu navigation



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

}