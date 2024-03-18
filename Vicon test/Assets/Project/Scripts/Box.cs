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
    fencer player;
    [SerializeField]
    fencer opponent;

    // states
    bool playerLightOn;
    bool opponentLightOn;
    bool timedOut;


    private void Start()
    {
        // subscribe to events
        GameManager.gameManager.OnOpponentHit += OpponentHit;
        GameManager.gameManager.OnPlayerHit += PlayerHit;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameManager.gameManager.OnOpponentHit -= OpponentHit;
        GameManager.gameManager.OnPlayerHit -= PlayerHit;
    }


    private void OpponentHit()
    {
        if (timedOut == false)
        {
            playerLightOn = true;
            // turn light on and play sound
            StartCoroutine(FencerHit(player, opponent));
        }
    }


    private void PlayerHit()
    {
        if (timedOut == false)
        {
            opponentLightOn = true;
            // turn light on and play sound
            StartCoroutine(FencerHit(opponent, player));
        }

    }


    IEnumerator FencerHit(fencer hitting, fencer gotHit)
    {
        if (!playerLightOn || !opponentLightOn)
        {
            StartCoroutine(TimeOut());
        }
        hitting.hit = true;
        gotHit.gotHit = true;
        yield return new WaitForSeconds(lightOffTime);
        hitting.hit = false;
        gotHit.gotHit = false;
        timedOut = false;
        // stop sound and lights
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(timedOutTime);
        timedOut = true;
    }
}
