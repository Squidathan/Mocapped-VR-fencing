using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StartActivity : MonoBehaviour
{
    bool playerInCollider = false;
    int collidersInCollider = 0;

    int startActivitiesToReject = 0;

    [SerializeField]
    AudioSource countdownAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerFoot"))
        {
            collidersInCollider++;

            if (playerInCollider == false)
            {
                playerInCollider = true;
                StartCoroutine(CountdownToActivity());
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerFoot"))
        {
            collidersInCollider--;

            if (collidersInCollider == 0) // if player not in collider
            {
                Debug.Log(startActivitiesToReject);
                startActivitiesToReject++;
                countdownAudioSource.Stop();
                playerInCollider = false;

            }
        }
    }


    IEnumerator CountdownToActivity()
    {
        countdownAudioSource.Play();
        yield return new WaitForSeconds(4);


        if (playerInCollider && startActivitiesToReject == 0)
        {
            BeginActivity();
            playerInCollider = false;
            collidersInCollider = 0;
            startActivitiesToReject = 0;
        }
        else
        {
            startActivitiesToReject--;
        }
    }

    public abstract void BeginActivity();
}
