using UnityEngine;

[DisallowMultipleComponent]
public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [Header("Interacción")]
    [SerializeField] protected string interactionPrompt = "Presiona E para interactuar";
    [SerializeField] protected bool singleUse = false;
    protected bool hasBeenUsed = false;
    public string InteractionPrompt => interactionPrompt;

    public virtual bool CanInteract
    {
        get
        {
            if (singleUse && hasBeenUsed)
                return false;
            return MeetsConditions();
        }
    }
    protected virtual bool MeetsConditions() => true;
    public void Interact(PlayerInteractor interactor)
    {
        if (!CanInteract)
            return;
        OnInteract(interactor);
        if (singleUse)
            hasBeenUsed = true;
    }
    protected abstract void OnInteract(PlayerInteractor interactor);
}