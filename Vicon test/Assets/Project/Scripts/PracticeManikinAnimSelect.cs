using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeManikinAnimSelect : MonoBehaviour
{
    [SerializeField]
    StaticManikin.ManikinAnimation anim;

    Material material;

    static List<PracticeManikinAnimSelect> instances = new List<PracticeManikinAnimSelect>();

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
            StaticManikin.staticManikin.manikinAnimation = anim;
            foreach (PracticeManikinAnimSelect instance in instances)
            {
                instance.UpdateSelection();
            }
            
        }
    }

    public void UpdateSelection()
    {
        if (StaticManikin.staticManikin.manikinAnimation == anim)
        {
            material.SetColor("_Color", Color.yellow);
        }
        else
        {
            material.SetColor("_Color", Color.grey);
        }
    }
}
