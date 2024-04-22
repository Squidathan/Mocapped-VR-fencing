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
        // commenting out these lines fixes issues detailed in ToActivityMenu for some reason if reset activty also doesnt run
        //if (state == ActivityState.Activity)
        //{

            ToActivityMenu();

        //}



        settingsMenu.SetActive(false);
    }

    // go to activity menu
    public virtual void ToActivityMenu()
    {
        //ResetActivity();
        //Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~################~~~~~~~~~~~~~"); // this line works
        activityObject.SetActive(false); // this line not working only for going from back th main menu for some reason
        settingsMenu.SetActive(true); // this line also doesn't work but only when being called from back to main menu
        state = ActivityState.Menu; // this line works
        
    }

    // go to activity
    public virtual void BeginActivity()
    {
        settingsMenu.SetActive(false);
        activityObject.SetActive(true);
        state = ActivityState.Activity;
        Debug.Log("begin activity");
    }


    // freezes time
    
    public void PauseActivity()
    {
        
        //Debug.Log("pause");
        
    }

    // re-enables time after a couple seconds if needed
    public void UnPauseActivity()
    {
        
        //Debug.Log("play");
        
    }


    // to implement in child class

    // reset activity settings to defaults
    public abstract void ResetSettings();

    // activity goes back to how it was before starting but at current settings
    public abstract void ResetActivity();

    


}
