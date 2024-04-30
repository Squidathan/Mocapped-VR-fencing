using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pointsActivity : Activity
{
    [SerializeField]
    int endMessageTime = 5;

    [SerializeField]
    GameObject lossMessage;
    [SerializeField]
    GameObject winMessage;
    

    public int pointsToGoTo = 5;

    private void OnDisable()
    {
        winMessage.SetActive(false);
        lossMessage.SetActive(false);
    }

    public IEnumerator Win()
    {
        
        winMessage.SetActive(true);
        yield return new WaitForSeconds(endMessageTime);
        winMessage.SetActive(false);
        ToActivityMenu();
    }

    public IEnumerator Loss()
    {
        lossMessage.SetActive(true);
        yield return new WaitForSeconds(endMessageTime);
        lossMessage.SetActive(false);
        ToActivityMenu();
    }
}
