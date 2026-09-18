using UnityEngine;

public class Jugador
{
    private int vida;
    private int daño;

    public Jugador(int vidaInicial, int dañoInicial)
    {
        vida = Mathf.Clamp(vidaInicial, 0, 100);
        daño = Mathf.Clamp(dañoInicial, 0, 100);
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0)
            vida = 0;

        Debug.Log($"Jugador recibió {cantidad} de daño. Vida actual: {vida}");
    }

    public int ObtenerDaño()
    {
        return daño;
    }

    public int ObtenerVida()
    {
        return vida;
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }
}
