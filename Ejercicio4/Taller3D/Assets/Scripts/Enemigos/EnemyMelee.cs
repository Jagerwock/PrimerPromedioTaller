using System;
using UnityEngine;

public class EnemyMelee : EnemyParent
{
    [SerializeField]private int startingMeleeHP;
    [SerializeField] private int startingMeleeDMG;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        enemyHealth = startingMeleeHP;
        enemyDamage = startingMeleeDMG;
    }
    public void RecieveDMG(int cantidad)
    {
        enemyHealth -= cantidad;
        if (enemyHealth < 0)
            enemyHealth = 0;

        Debug.Log($"el enemigo recibió {cantidad} de daño. Vida actual del enemigo: {enemyHealth}");
    }

    public int ObtenerDaño()
    {
        return enemyDamage;
    }

    public bool VivoMuerto()
    {
        return enemyHealth > 0;
    }
}
