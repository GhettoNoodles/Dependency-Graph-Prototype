using System.Collections.Generic;
using UnityEngine;

public class DependencyNode : MonoBehaviour
{
    [SerializeField] private bool unlocked = false;
    [SerializeField] private bool interactable = false;
    [SerializeField] private bool atLeastOne;
    [SerializeField] private List<DependencyNode> dependentOn;
    [SerializeField] private MeshRenderer mr;

    private void Update()
    {
        CheckInteractibility();
        if (interactable)
        {
            mr.material.color = Color.green;
        }
        else
        {
            mr.material.color = Color.red;
        }

        if (unlocked)
        {
            mr.material.color = Color.blue;
        }
    }

    public void CheckInteractibility()
    {
        interactable = !atLeastOne;
        foreach (var node in dependentOn)
        {
            if (!atLeastOne)
            {
                if (!node.GetStatus())
                {
                    interactable = false;
                }
            }
            else
            {
                if (node.GetStatus())
                {
                    interactable = true;
                }
            }
        }
    }

    public bool GetStatus()
    {
        return unlocked;
    }
}