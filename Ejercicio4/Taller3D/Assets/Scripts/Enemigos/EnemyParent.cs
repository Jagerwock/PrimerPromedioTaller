using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected int enemyDamage;

    public void Inicializar(int vida, int daño)
    {
        enemyHealth = Mathf.Max(0, vida);
        enemyDamage = Mathf.Max(0, daño);
    }

    public void RecibirDaño(int cantidad)
    {
        enemyHealth -= Mathf.Max(0, cantidad);
        if (enemyHealth < 0)
            enemyHealth = 0;

        Debug.Log($"{name} recibió {cantidad} de daño. Vida actual: {enemyHealth}");
    }

    public int ObtenerDaño()
    {
        return enemyDamage;
    }

    public int ObtenerVida()
    {
        return enemyHealth;
    }

    public bool EstaVivo()
    {
        return enemyHealth > 0;
    }

}
