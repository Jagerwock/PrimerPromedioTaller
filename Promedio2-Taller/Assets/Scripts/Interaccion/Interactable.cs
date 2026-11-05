using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject aviso;

    public virtual GameObject Aviso => aviso;
    public virtual bool CanInteract => true;

    public abstract void Interact(PlayerInteractor user);

    public virtual void InteractAlternate(PlayerInteractor user)
    {
    }
}
