using System;

class Exercicio1
{
    static void lerVetor(int[] vetor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write($"Digite o {i + 1}° valor: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }
    }
    static int somarVetor(int[] vetor)
    {
        int soma = 0;

        for (int i = 0; i < vetor.Length; i++)
        {
            soma = soma + vetor[i];
        }

        return soma;
    }

    static void Main()
    {
        int t;

        Console.Write("Qual o tamanho do vetor: ");
        t = int.Parse(Console.ReadLine());

        int[] vetor = new int[t];

        lerVetor(vetor);
        somarVetor(vetor);

        Console.WriteLine($"A soma dos valores digitados é {somarVetor(vetor)}");
    }
}