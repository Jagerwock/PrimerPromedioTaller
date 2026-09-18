using System;
using UnityEngine;

public class EnemyMelee : EnemyParent
{
    [SerializeField] private int startingMeleeHP;
    [SerializeField] private int startingMeleeDMG;
    private void Awake()
    {
        Inicializar(startingMeleeHP, startingMeleeDMG);
    }
    public void RecieveDMG(int cantidad)
    {
        RecibirDaño(cantidad);
    }

    public bool VivoMuerto()
    {
        return EstaVivo();
    }
}
