using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PointBox : Box
{
    [SerializeField]
    MeshRenderer playerScoreRenderer;
    [SerializeField]
    MeshRenderer opponentScoreRenderer;

    [SerializeField]
    ParryReposte activity;

    [SerializeField]
    TextMeshPro playerScoreText;
    [SerializeField]
    TextMeshPro opponentScoreText;

    [SerializeField]
    Slider playerHealth;

    [SerializeField]
    Slider opponentHealth;

    int playerScore = 0;
    int opponentScore = 0;

    bool ended = false;

    private void OnEnable()
    {
        playerHealth.maxValue = activity.pointsToGoTo;
        playerHealth.value = activity.pointsToGoTo;
        opponentHealth.maxValue = activity.pointsToGoTo;
        opponentHealth.value = activity.pointsToGoTo;

        if (activity.gamified)
        {
            playerScoreRenderer.enabled = false;
            opponentScoreRenderer.enabled = false;
        }
        else
        {
            playerScoreRenderer.enabled = true;
            opponentScoreRenderer.enabled = true;
        }

        playerScore = 0;
        opponentScore = 0;

        ended = false;
    }

    protected override void CalculatePoints()
    {
        if (opponentLightOn)
        {
            opponentScore++;
            playerHealth.value--;
            opponentScoreText.text = opponentScore.ToString();
            if (opponentScore == activity.pointsToGoTo)
            {
                ended = true;
                StartCoroutine(activity.Loss());
            }
        }
        else if (playerLightOn)
        {
            playerScore++;
            opponentHealth.value--;
            playerScoreText.text = playerScore.ToString();
            Debug.Log("player score increase");
            if (playerScore == activity.pointsToGoTo)
            {
                Debug.Log("win");
                ended = true;
                StartCoroutine(activity.Win());
            }
        }
    }

    protected override void PlayerHit()
    {
        if (ended)
            return;
        base.PlayerHit();
    }

    protected override void OpponentHit()
    {
        if (ended)
            return;
        base.OpponentHit();
    }


}
