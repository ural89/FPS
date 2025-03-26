using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTextHandler : MonoBehaviour, IInteractionTextHandler
{
    [SerializeField] private TMP_Text interactionText;
    public void SetInteractionText(bool isActive, string tutorialText = null)
    {
        interactionText.gameObject.SetActive(isActive);
        if (!isActive)
        {
            interactionText.text = string.Empty;
            return;
        }
        if (interactionText == null)
        {
            Debug.LogError("Interaction tutorial text is not assigned.");
            return;
        }

        if (tutorialText != null)
        {
            interactionText.text = tutorialText;
        }
    }

  
}
