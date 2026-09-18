using UnityEngine;

public class Jugador
{
    private int vida;
    private int daño;

    public Jugador(int vidaInicial, int dañoInicial)
    {
        vida = vidaInicial;
        daño = dañoInicial;
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
}
