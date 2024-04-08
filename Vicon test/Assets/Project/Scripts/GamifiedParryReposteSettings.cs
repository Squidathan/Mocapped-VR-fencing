using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamifiedParryReposteSettings : MonoBehaviour
{
    [SerializeField]
    bool gamified;

    Material material;

    static List<GamifiedParryReposteSettings> instances = new List<GamifiedParryReposteSettings>();

    private void OnEnable()
    {
        instances.Add(this);
        material = GetComponent<Renderer>().material;
        UpdateSelection();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerSword")
        {
            ParryReposte.parryReposte.gamified = gamified;
            foreach (GamifiedParryReposteSettings instance in instances)
            {
                instance.UpdateSelection();
            }

        }
    }

    public void UpdateSelection()
    {
        if (ParryReposte.parryReposte.gamified == gamified)
        {
            material.SetColor("_Color", Color.yellow);
        }
        else
        {
            material.SetColor("_Color", Color.grey);
        }
    }
}
