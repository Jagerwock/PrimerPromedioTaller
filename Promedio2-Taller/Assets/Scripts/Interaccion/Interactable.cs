using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual string Prompt => "[E] Interactuar";
    public virtual bool CanInteract => true;

    public abstract void Interact(PlayerInteractor user);
}