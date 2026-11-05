using UnityEngine;

public class Mailbox : Interactable
{
    [SerializeField] private Caso caso;

    public override bool CanInteract => caso.Actual == Caso.Etapa.PorRecibir;

    public override void Interact(PlayerInteractor user)
    {
        caso.RecibirCaja();
    }
}
