public class EnemigoRango : Personaje
{
    private int balas;

    public EnemigoRango(int vidaInicial, int dañoInicial) : base(vidaInicial, dañoInicial)
    {
        balas = 2;
    }

    public override int ObtenerDaño()
    {
        if (balas == 0)
        {
            return 0;
        }

        balas--;
        return daño;
    }

    public int ObtenerBalas()
    {
        return balas;
    }
}
