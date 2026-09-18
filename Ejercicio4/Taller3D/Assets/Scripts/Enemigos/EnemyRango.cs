using UnityEngine;

public class EnemyRango : EnemyParent
{
    [SerializeField] private int startingRangoHP;
    [SerializeField] private int startingRangoDMG;
    [SerializeField] private int balas;

    private void Awake()
    {
        Inicializar(startingRangoHP, startingRangoDMG);
        balas = Mathf.Max(0, balas);
    }

    public int Atacar()
    {
        if (!EstaVivo() || balas <= 0)
            return 0;

        balas--;
        return ObtenerDaño();
    }

    public int ObtenerBalas()
    {
        return balas;
    }
}
