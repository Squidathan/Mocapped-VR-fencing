using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryReposteNumberOfPointsSetting : MonoBehaviour
{
    [SerializeField]
    int numberOfPoints;

    Material material;

    static List<ParryReposteNumberOfPointsSetting> instances = new List<ParryReposteNumberOfPointsSetting>();

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
            ParryReposte.parryReposte.pointsToGoTo = numberOfPoints;
            foreach (ParryReposteNumberOfPointsSetting instance in instances)
            {
                instance.UpdateSelection();
            }

        }
    }

    public void UpdateSelection()
    {
        if (ParryReposte.parryReposte.pointsToGoTo == numberOfPoints)
        {
            material.SetColor("_Color", Color.yellow);
        }
        else
        {
            material.SetColor("_Color", Color.grey);
        }
    }
}
