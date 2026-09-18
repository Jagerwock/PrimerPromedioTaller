using System;
using UnityEngine;

public class Juego : MonoBehaviour
{
    [Header("Jugador")]
    [SerializeField] private int vidaJugador = 100;
    [SerializeField] private int dañoJugador = 25;

    [Header("Enemigos")]
    [SerializeField] private EnemyMelee enemigoMelee;
    [SerializeField] private EnemyRango enemigoRango;
    [SerializeField] private int enemigoSeleccionado;

    private Jugador jugador;
    private EnemyParent[] enemigos;
    private int turnoEnemigo;
    private bool juegoTerminado;

    private void Start()
    {
        jugador = new Jugador(vidaJugador, dañoJugador);
        enemigos = new EnemyParent[] { enemigoMelee, enemigoRango };
        Debug.Log($"Comienza el juego. Vida: {jugador.ObtenerVida()}, daño: {jugador.ObtenerDaño()}");
    }

    [ContextMenu("Atacar enemigo seleccionado")]
    public void AtacarEnemigoSeleccionado()
    {
        if (juegoTerminado)
            return;

        if (enemigoSeleccionado < 0 || enemigoSeleccionado >= enemigos.Length)
        {
            Debug.Log("Elige el enemigo 0 (melee) o 1 (rango).");
            return;
        }

        EnemyParent enemigo = enemigos[enemigoSeleccionado];
        if (enemigo == null)
        {
            Debug.Log("Falta asignar el enemigo en el Inspector.");
            return;
        }

        if (!enemigo.EstaVivo())
        {
            Debug.Log("Ese enemigo ya está muerto. Elige otro.");
            return;
        }

        enemigo.RecibirDaño(jugador.ObtenerDaño());

        if (TodosLosEnemigosMuertos())
        {
            juegoTerminado = true;
            Debug.Log("Victoria: todos los enemigos fueron derrotados.");
            return;
        }

        TurnoDelEnemigo();
    }

    private void TurnoDelEnemigo()
    {
        EnemyParent enemigo = BuscarSiguienteEnemigoVivo();
        if (enemigo == null)
            return;

        int daño = enemigo.ObtenerDaño();

        if (enemigo is EnemyRango enemigoQueDispara)
        {
            daño = enemigoQueDispara.Atacar();
            if (daño == 0)
                Debug.Log($"{enemigo.name} no tiene balas y pierde su turno.");
            else
                Debug.Log($"{enemigo.name} dispara. Balas restantes: {enemigoQueDispara.ObtenerBalas()}");
        }

        if (daño > 0)
            jugador.RecibirDaño(daño);

        if (!jugador.EstaVivo())
        {
            juegoTerminado = true;
            Debug.Log("Derrota: el jugador se quedó sin vida.");
        }
    }

    private EnemyParent BuscarSiguienteEnemigoVivo()
    {
        for (int i = 0; i < enemigos.Length; i++)
        {
            int posicion = (turnoEnemigo + i) % enemigos.Length;
            EnemyParent enemigo = enemigos[posicion];

            if (enemigo != null && enemigo.EstaVivo())
            {
                turnoEnemigo = (posicion + 1) % enemigos.Length;
                return enemigo;
            }
        }

        return null;
    }

    private bool TodosLosEnemigosMuertos()
    {
        foreach (EnemyParent enemigo in enemigos)
        {
            if (enemigo != null && enemigo.EstaVivo())
                return false;
        }

        return true;
    }
}
