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

    // lights
    [SerializeField]
    GameObject playerLight;
    [SerializeField]
    GameObject opponentLight;

    Material playerLightMaterial;
    Material opponentLightMaterial;

    private void Start()
    {
        // subscribe to events
        GameManager.gameManager.OnOpponentHit += OpponentHit;
        GameManager.gameManager.OnPlayerHit += PlayerHit;

        playerLightMaterial = playerLight.GetComponent<Renderer>().material;
        opponentLightMaterial = opponentLight.GetComponent<Renderer>().material;
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
            playerLightMaterial.EnableKeyword("_EMISSION");
            StartCoroutine(FencerHit(player, opponent));
            audioSource.Play();
        }
    }


    private void PlayerHit()
    {
        if (timedOut == false)
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
        hitting.hit = false;
        gotHit.gotHit = false;
        timedOut = false;

        // stop sound and lights
        opponentLightMaterial.DisableKeyword("_EMISSION");
        playerLightMaterial.DisableKeyword("_EMISSION");
        audioSource.Stop();
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(timedOutTime);
        timedOut = true;
    }
}
