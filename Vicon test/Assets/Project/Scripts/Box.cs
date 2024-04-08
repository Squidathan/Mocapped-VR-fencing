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
    protected bool playerLightOn;
    protected bool opponentLightOn;
    protected bool timedOut;

    // lights
    [SerializeField]
    GameObject playerLight;
    [SerializeField]
    GameObject opponentLight;

    Material playerLightMaterial;
    Material opponentLightMaterial;

    protected virtual void Start()
    {
        // subscribe to events
        GameManager.gameManager.OnOpponentHit += OpponentHit;
        GameManager.gameManager.OnPlayerHit += PlayerHit;

        playerLightMaterial = playerLight.GetComponent<Renderer>().material;
        opponentLightMaterial = opponentLight.GetComponent<Renderer>().material;
    }

    protected virtual void OnDestroy()
    {
        // unsubscribe from events
        GameManager.gameManager.OnOpponentHit -= OpponentHit;
        GameManager.gameManager.OnPlayerHit -= PlayerHit;
    }


    protected virtual void OpponentHit()
    {
        if (timedOut == false && playerLightOn == false)
        {
            Debug.Log("opponentHit");
            playerLightOn = true;

            // turn light on and play sound
            playerLightMaterial.EnableKeyword("_EMISSION");
            StartCoroutine(FencerHit(player, opponent));
            audioSource.Play();
        }
    }


    protected virtual void PlayerHit()
    {
        if (timedOut == false && opponentLightOn == false)
        {
            opponentLightOn = true;

            // turn light on and play sound
            opponentLightMaterial.EnableKeyword("_EMISSION");
            StartCoroutine(FencerHit(opponent, player));
            audioSource.Play();
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
        CalculatePoints();

        hitting.hit = false;
        gotHit.gotHit = false;
        timedOut = false;

        // stop sound and lights
        opponentLightMaterial.DisableKeyword("_EMISSION");
        opponentLightOn = false;
        playerLightMaterial.DisableKeyword("_EMISSION");
        playerLightOn = false;
        audioSource.Stop();
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(timedOutTime);
        timedOut = true;
    }


    protected virtual void CalculatePoints()
    {

    }
}
