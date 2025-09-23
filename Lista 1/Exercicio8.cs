using System;

class Exercicio8
{
    static void Main()
    {
        Console.Write("Digite o tamanho do vetor: ");
        int N = int.Parse(Console.ReadLine());

        int[] vetor = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write($"Digite o valor da posição {i + 1}: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nElementos do vetor:");
        for (int i = 0; i < N; i++)
        {
            Console.Write(vetor[i] + " ");
        }
        Console.WriteLine();

        Console.Write("\nDigite um valor para procurar no vetor: ");
        int numero = int.Parse(Console.ReadLine());

        int contagem = 0;

        for (int i = 0; i < N; i++)
        {
            if (vetor[i] == numero)
            {
                contagem++;
            }
        }

        if (contagem > 0)
        {
            Console.WriteLine($"\nO número {numero} apareceu {contagem} vezes no vetor.");
        }
        else
        {
            Console.WriteLine($"\nO número {numero} não apareceu no vetor.");
        }
    }
}
