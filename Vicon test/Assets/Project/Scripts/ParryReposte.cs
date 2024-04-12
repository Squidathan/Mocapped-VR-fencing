using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryReposte : pointsActivity
{
    [SerializeField]
    GameObject usualModel;

    [SerializeField]
    GameObject gamifiedModel;

    //[SerializeField]
    //GameObject usualSabre;

    //[SerializeField]
    //GameObject gamifiedSabre;

    [SerializeField]
    List<GameObject> room = new List<GameObject>();

    [SerializeField]
    List<GameObject> environment = new List<GameObject>();

    [SerializeField]
    Box box;

    //settings
    public bool gamified = false;

    public override void BeginActivity()
    {
        base.BeginActivity();

        if (gamified == false)
        {
            usualModel.SetActive(true);
            gamifiedModel.SetActive(false);

            //usualSabre.SetActive(true);
            //gamifiedSabre.SetActive(false);

            SetEnvironment(false);
        }
        else if (gamified == true)
        {
            usualModel.SetActive(false);
            gamifiedModel.SetActive(true);

            //usualSabre.SetActive(true);
            //gamifiedSabre.SetActive(true);

            SetEnvironment(true);

        }
    }

    void SetEnvironment(bool environmentSet)
    {
        foreach (GameObject gameObject in room)
        {
            gameObject.SetActive(!environmentSet);
        }

        foreach (GameObject gameObject in environment)
        {
            gameObject.SetActive(environmentSet);
        }

    }




    public override void ToActivityMenu()
    {
        base.ToActivityMenu();

        foreach (GameObject gameObject in room)
        {
            gameObject.SetActive(true);
        }

    }



    public override void ResetActivity()
    {
        //box.ResetBox();
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
