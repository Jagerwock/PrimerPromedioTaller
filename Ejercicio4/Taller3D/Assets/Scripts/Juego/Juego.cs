using System;
using UnityEngine;

internal class Juego : MonoBehaviour
{
    public string playername;
    public string name1;
    public int lifePlayer;
    public bool TheGameIsOver = true;
    public int option;
    public void Execute()
    {
        RunGame();
    }
    private void RunGame()
    {
        if (TheGameIsOver == true)
        {
            Final();
        }
    }
    public void Run()
    {
        Console.WriteLine("Introdusca su nombre:");
        playername = Console.ReadLine();
        name1 = playername;
        lifePlayer = 3;
        Console.WriteLine($"Su nombre es {name1} y su cantidad de vida es {lifePlayer}");
        if (lifePlayer == 0)
        {
            Retry();
        }
    }
    private void Retry()
    {
        Console.WriteLine("Desea volver a intentar? 1=si 2=no");
        option = Convert.ToInt32(Console.ReadLine());
        if (option == 1)
        {
            TheGameIsOver = true;
            lifePlayer = 3;
            RunGame();
        }
        else
        {
            TheGameIsOver = false;
            Environment.Exit(0);
        }
    }
    public void Final()
    {
        Console.WriteLine("El juego ha terminado");
        Console.WriteLine("Desea volver a intentar? 1=si 2=no");
        option = Convert.ToInt32(Console.ReadLine());
        if (option == 1)
        {
            TheGameIsOver = true;
            lifePlayer = 3;
            RunGame();
        }
        else
        {
            TheGameIsOver = false;
            Environment.Exit(0);
        }
    }
}
