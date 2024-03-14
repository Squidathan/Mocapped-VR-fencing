using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManikinEnable : MonoBehaviour
{
    // Event subscriptions
    void Start()
    {
        // Enabling and disabling the objects if changing state
        GameManager.gameManager.OnStaticManikin += EnableStaticManikin;
    }
    private void OnDestroy()
    {
        // Unsubscribe from nabling and disabling the objects if changing state
        GameManager.gameManager.OnStaticManikin -= EnableStaticManikin;
    }

    [SerializeField]
    GameObject staticManikinEnableObject;

    // Called when activity selected
    void EnableStaticManikin()
    {
        staticManikinEnableObject.SetActive(true);
    }



}
