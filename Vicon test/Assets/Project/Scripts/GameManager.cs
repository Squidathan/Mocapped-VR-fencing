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
        activitySelect,
        StaticManikin
    }
    [SerializeField]
    public static gameMode state = gameMode.activitySelect;


    private void Start()
    {
        Menu();
    }




    //Events

    // select Static manikin activity
    public event Action OnStaticManikin;
    public void StaticManikin()
    {
        state = gameMode.StaticManikin;
        OnStaticManikin?.Invoke();
    }

    // select to go to menu
    public event Action onMenu;
    public void Menu()
    {
        state = gameMode.activitySelect;
        onMenu?.Invoke();
    }


}
