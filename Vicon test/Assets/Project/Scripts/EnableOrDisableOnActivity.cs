using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableOrDisableOnActivity : MonoBehaviour
{
    [SerializeField]
    GameObject menuEnable;

    [SerializeField]
    bool enable = true;

    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.OnStaticManikin += enableMenu;
    }
    private void OnDestroy()
    {
        // Unsubscribe from nabling and disabling the objects if changing state
        GameManager.gameManager.OnStaticManikin -= enableMenu;
    }

    // Called when activty selected
    void enableMenu()
    {
        menuEnable.SetActive(enable);
    }
}
