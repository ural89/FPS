using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    public string GetInteractableName()
    {
        return "Door";
    }

    public void Interact()
    {
        transform.Rotate(0, 90, 0);
    }

    public bool IsInteractable()
    {
        return true;
    }
}
