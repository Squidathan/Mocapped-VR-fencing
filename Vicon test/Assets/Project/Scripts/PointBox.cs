using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointBox : Box
{
    [SerializeField]
    pointsActivity activity;

    [SerializeField]
    TextMeshPro playerScoreText;
    [SerializeField]
    TextMeshPro opponentScoreText;

    int playerScore = 0;
    int opponentScore = 0;

    bool ended = false;

    protected override void CalculatePoints()
    {
        if (opponentLightOn)
        {
            opponentScore++;
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
