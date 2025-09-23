using System;

class Exercicio10
{
    static void Main()
    {
        int QuantidadeLancamentos;
        int k1 = 0, k2 = 0,k3 = 0, k4 = 0, k5 = 0, k6 = 0;

        Console.Write("Quantidade de lançamentos: ");
        QuantidadeLancamentos = int.Parse(Console.ReadLine());

        Random rnd = new Random();

        for (int i = 0; i < QuantidadeLancamentos; i++)
        {
            int lado = rnd.Next(1, 7);

            if (lado == 1)
            {
                k1++;
            }
            else if (lado == 2)
            {
                k2++;
            }
            else if (lado == 3)
            {
                k3++;
            }
            else if (lado == 4)
            {
                k4++;
            }
            else if (lado == 5)
            {
                k5++;
            }
            else if (lado == 6)
            {
                k6++;
            }
        }

        Console.WriteLine($"O dado foi lançado {QuantidadeLancamentos} vezes, tendo os resultados:");
        Console.WriteLine($"{k1} vezes no n° 1");
        Console.WriteLine($"{k2} vezes no n° 2");
        Console.WriteLine($"{k3} vezes no n° 3");
        Console.WriteLine($"{k4} vezes no n° 4");
        Console.WriteLine($"{k5} vezes no n° 5");
        Console.WriteLine($"{k6} vezes no n° 6");
    }
}