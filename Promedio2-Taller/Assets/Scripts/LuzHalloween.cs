using UnityEngine;

public class LuzHalloween : Interactable
{
    [SerializeField] private Light luz;

    public override void Interact(PlayerInteractor user)
    {
        luz.enabled = !luz.enabled;
    }
}
