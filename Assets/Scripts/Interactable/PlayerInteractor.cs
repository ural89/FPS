using UnityEngine;
using Zenject;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float interactionDistance = 5.0f;
    private IInteractionTextHandler tutorialHandler;
    private Camera cam;

    [Inject]
    public void Construct(IInteractionTextHandler tutorialHandler)
    {
        this.tutorialHandler = tutorialHandler;
        this.tutorialHandler.SetInteractionText(false);
    }
    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        CheckForInteractableName();
    }
    public IInteractable InteractWithRaycast()
    {

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null && interactable.IsInteractable())
            {
                interactable.Interact();
                return interactable;
            }
            return null;
        }
        return null;
    }
    public void CheckForInteractableName()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null && interactable.IsInteractable())
            {
                tutorialHandler.SetInteractionText(true, interactable.GetInteractableName());
            }
        }
        else
        {
            tutorialHandler.SetInteractionText(false);
        }
    }


}
