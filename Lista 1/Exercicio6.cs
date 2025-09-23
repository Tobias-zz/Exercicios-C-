using System;

class Exercicio6
{
    static void Main()
    {
        Console.Write("Quantos números você quer sortear? ");
        int N = int.Parse(Console.ReadLine());

        int[] vetor = new int[N];
        Random rand = new Random();

        
        for (int i = 0; i < N; i++)
        {
            vetor[i] = rand.Next(1, 101);
        }

        
        Console.WriteLine("\nNúmeros sorteados:");
        for (int i = 0; i < N; i++)
        {
            Console.Write(vetor[i] + " ");
        }
        Console.WriteLine();

        Console.Write("\nDigite um número para procurar no vetor: ");
        int numero = int.Parse(Console.ReadLine());

        bool achei = false;

        for (int i = 0; i < N; i++)
        {
            if (vetor[i] == numero)
            {
                Console.WriteLine($"Achei o número {numero} na posição {i + 1} do vetor!");
                achei = true;
            }
        }

        if (!achei)
        {
            Console.WriteLine($"O número {numero} não apareceu em nenhuma posição do vetor.");
        }
    }
}
