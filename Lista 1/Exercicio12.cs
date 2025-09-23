using System;

class Exercicio12
{


    static void Main()
    {

        string entrada = Console.ReadLine();

        string[] notas = entrada.Split(' ');

        float[] valorNotas = new float[notas.Length];

        for (int i = 0; i < notas.Length; i++)
        {
            valorNotas[i] = float.Parse(notas[i]);
        }

        float maior = valorNotas[0];
        float menor = valorNotas[0];

        for (int i = 0; i < notas.Length; i++)
        {
            if (maior < valorNotas[i])
                maior = valorNotas[i];
            if (menor > valorNotas[i])
                menor = valorNotas[i];
        }

        float soma = 0;

        for (int i = 0; i < notas.Length; i++)
        {
            soma += valorNotas[i];
        }

        soma = soma - maior - menor;

        Console.Write($"{soma:F1}");
    }
}