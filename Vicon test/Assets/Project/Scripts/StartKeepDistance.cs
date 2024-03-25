using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKeepDistance : MonoBehaviour
{
    bool startActivity = true;
    [SerializeField]
    AudioSource countdownAudioSource;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            startActivity = true;
            StartCoroutine(CountdownToActivity());
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startActivity = false;
            countdownAudioSource.Stop();
            StopCoroutine(CountdownToActivity());
        }


    }


    IEnumerator CountdownToActivity()
    {
        countdownAudioSource.Play();
        yield return new WaitForSeconds(4);
        //Debug.Log("trying to start activity");
        if (startActivity == true)
        {
            Debug.Log("start activity");
            KeepDistance.keepDistance.BeginActivity();
        }
    }
}
