using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistanceBox : MonoBehaviour
{
    [SerializeField]
    GameObject opponentLight;
    Material opponentLightMaterial;
    

    [SerializeField]
    AudioSource audioSource;

    private void Start()
    {
        opponentLightMaterial = opponentLight.GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        OutOfCollider();
    }

    public void InCollider()
    {
        opponentLightMaterial.DisableKeyword("_EMISSION");
        audioSource.Stop();

    }

    public void OutOfCollider()
    {
        opponentLightMaterial.EnableKeyword("_EMISSION");
        audioSource.Play();

    }

}
