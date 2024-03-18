using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // sounds
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip hitSound;

    // timings
    [SerializeField]
    float timedOutTime;
    [SerializeField]
    float lightOffTime;

    // fencers
    [SerializeField]
    fencer fencerOne;
    [SerializeField]
    fencer fencerTwo;

    // states
    bool fencerOneLightOn;
    bool fencerTwoLightOn;
    bool timedOut;


    private void Start()
    {
        // subscribe to events
        GameManager.gameManager.OnOpponentHit += OpponentHit;
        GameManager.gameManager.OnBladeClash += BladeClash;
        GameManager.gameManager.OnPlayerHit += PlayerHit;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameManager.gameManager.OnOpponentHit -= OpponentHit;
        GameManager.gameManager.OnBladeClash -= BladeClash;
        GameManager.gameManager.OnPlayerHit -= PlayerHit;
    }

    private void OpponentHit()
    {

    }

    private void BladeClash()
    {

    }

    private void PlayerHit()
    {

    }


    IEnumerator FencerHit(fencer fencer)
    {
        fencer.hit = true;
        yield return new WaitForSeconds(lightOffTime);
        fencer.hit = false;
    }
}
