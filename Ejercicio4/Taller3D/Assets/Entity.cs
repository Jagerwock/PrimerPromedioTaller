using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int startingHP;
    [SerializeField] private int startingDMG;

    protected int health;
    protected int damage;

    protected virtual void Start()
    {
        health = startingHP;
        damage = startingDMG;
    }

    public virtual void RecieveDMG(int cantidad)
    {
        health -= cantidad;

        if (health < 0)
        {
            health = 0;
        }

        Debug.Log($"{gameObject.name} recibió {cantidad} de daño. Vida actual: {health}");
    }

    public int ObtenerDaño()
    {
        return damage;
    }

    public bool VivoMuerto()
    {
        return health > 0;
    }
}