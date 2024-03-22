using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Activity : MonoBehaviour
{
    [SerializeField]
    protected GameObject activityObject;

    [SerializeField]
    protected GameObject settingsMenu;



    public enum ActivityState
    {
        Menu,
        Activity
    }
    public static ActivityState state = ActivityState.Menu;


    // called on return to main menu
    public void BackToMainMenu()
    {
        ToActivityMenu();
        settingsMenu.SetActive(false);
    }

    // go to activity menu
    public void ToActivityMenu()
    {
        ResetActivity();

        activityObject.SetActive(false);
        settingsMenu.SetActive(true);
        state = ActivityState.Menu;
        
    }

    // go to activity
    public void BeginActivity()
    {
        settingsMenu.SetActive(false);
        activityObject.SetActive(true);
        state = ActivityState.Activity;
    }


    // freezes time
    
    public void PauseActivity()
    {
        Time.timeScale = 0;
    }

    // re-enables time after a couple seconds if needed
    public void UnPauseActivity()
    {
        Time.timeScale = 1;
    }


    // to implement in child class

    // reset activity settings to defaults
    public abstract void ResetSettings();

    // activity goes back to how it was before starting but at current settings
    public abstract void ResetActivity();

    


}
