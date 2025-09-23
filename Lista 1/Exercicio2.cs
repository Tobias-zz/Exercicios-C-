using System;

class Exercicio2
{
    static void lerVetor(int[] vetor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write($"Digite o {i + 1}° valor: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }
    }
    static int valoresImparesVetor(int[] vetor)
    {
        int qntImpares = 0;

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] % 2 != 0)
            {
                qntImpares++;
            }
        }

        return qntImpares;
    }

    static void Main()
    {
        int t;

        Console.Write("Qual o tamanho do vetor: ");
        t = int.Parse(Console.ReadLine());

        int[] vetor = new int[t];

        lerVetor(vetor);
        valoresImparesVetor(vetor);

        Console.WriteLine($"Foram digitados {valoresImparesVetor(vetor)} valores ímpares.");
    }
}