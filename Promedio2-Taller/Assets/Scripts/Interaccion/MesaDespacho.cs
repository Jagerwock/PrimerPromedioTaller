using UnityEngine;

public class MesaDespacho : Interactable
{
    [SerializeField] private Caso caso;
    [SerializeField] private Transform punto;

    public override bool CanInteract => caso.Actual == Caso.Etapa.Sellada;

    public override void Interact(PlayerInteractor user)
    {
        caso.DespacharCaja(punto);
    }
}
