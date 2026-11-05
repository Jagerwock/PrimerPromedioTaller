using UnityEngine;

public class MesaInspeccion : Interactable
{
    [SerializeField] private Caso caso;
    [SerializeField] private GameObject avisoUV;
    [SerializeField] private GameObject avisoDecision;

    public override GameObject Aviso
    {
        get
        {
            if (caso.Actual == Caso.Etapa.EnMano)
                return base.Aviso;
            if (caso.Actual == Caso.Etapa.EnMesa)
                return avisoUV;
            return avisoDecision;
        }
    }

    public override bool CanInteract => caso.Actual == Caso.Etapa.EnMano
        || caso.Actual == Caso.Etapa.EnMesa
        || caso.Actual == Caso.Etapa.Revisada;

    public override void Interact(PlayerInteractor user)
    {
        if (caso.Actual == Caso.Etapa.EnMano)
            caso.ColocarLinterna();
        else if (caso.Actual == Caso.Etapa.EnMesa)
            caso.ProbarUV();
        else
            caso.Decidir(true);
    }

    public override void InteractAlternate(PlayerInteractor user)
    {
        if (caso.Actual == Caso.Etapa.Revisada)
            caso.Decidir(false);
    }
}
