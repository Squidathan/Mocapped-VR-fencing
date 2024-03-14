using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenu;

    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.onMenu += EnableMenu;
        GameManager.gameManager.OnActivity += DisableMenu;

    }
    private void OnDestroy()
    {
        // Unsubscribe from nabling and disabling the objects if changing state
        GameManager.gameManager.onMenu -= EnableMenu;
        GameManager.gameManager.OnActivity -= DisableMenu;
    }

    // Called when menu selected
    void EnableMenu()
    {
        MainMenu.SetActive(true);
    }

    // Called when activity selected
    void DisableMenu()
    {
        MainMenu.SetActive(false);
    }
}
