using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    //Have only one gameManager instance available everywhere
    public static GameManager gameManager;
    private void Awake()
    {
        gameManager = this;
    }

    // game type or menu select
    public enum gameMode
    {
        Menu,
        StaticManikin,
        KeepDistance,
        ParryReposte
    }
    public static gameMode state;


    private void Start()
    {
        Menu();
    }










    //Events

    // in game events

    // player hit
    public event Action OnPlayerHit;
    public void PlayerHit()
    {
        OnPlayerHit?.Invoke();
    }


    // opponent hit
    public event Action OnOpponentHit;
    public void OpponentHit()
    {
        OnOpponentHit?.Invoke();
    }


    // clash of blades
    public event Action OnBladeClash;
    public void BladeClash()
    {
        OnBladeClash?.Invoke();
    }

    // Corp-a-corp
    public event Action OnCorpACorp;
    public void CorpACorp()
    {
        OnCorpACorp?.Invoke();
    }
















    // activity selected
    public event Action OnActivity;


    // select Static manikin activity
    public event Action OnStaticManikin;
    public void StaticManikin()
    {
        state = gameMode.StaticManikin;
        OnStaticManikin?.Invoke();
        OnActivity?.Invoke();

    }




    // select Static manikin activity
    public event Action OnKeepDistance;
    public void KeepDistance()
    {
        state = gameMode.KeepDistance;
        OnKeepDistance?.Invoke();
        OnActivity?.Invoke();
    }


    // select parry reposte activity
    public event Action OnParryReposte;
    public void ParryReposte()
    {
        state = gameMode.ParryReposte;
        OnParryReposte?.Invoke();
        OnActivity?.Invoke();
    }




    // select to go to menu
    public event Action onMenu;
    public void Menu()
    {
        state = gameMode.Menu;
        onMenu?.Invoke();
        
    }


}
