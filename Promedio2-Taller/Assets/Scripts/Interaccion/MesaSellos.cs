using UnityEngine;

public class MesaSellos : Interactable
{
    [SerializeField] private Caso caso;

    public override bool CanInteract => caso.Actual == Caso.Etapa.PorSellar;

    public override void Interact(PlayerInteractor user)
    {
        caso.SellarCaja();
    }
}
