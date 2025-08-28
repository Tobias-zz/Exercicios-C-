using System;

class Exercicio3
{
    static void lerVetor(double[] vetor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write($"Digite o {i + 1}° valor: ");
            vetor[i] = double.Parse(Console.ReadLine());
        }
    }

    static void mostrarVetor(double[] vetor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write("|" + vetor[i]);
        }
    }
    static double menorValorVetor(double[] vetor)
    {

        double menorValor = vetor[0];

        for (int i = 0; i < vetor.Length; i++)
        {
            if (menorValor > vetor[i])
                menorValor = vetor[i];
        }

        return menorValor;
    }

    static void Main()
    {
        int t;

        Console.Write("Qual o tamanho do vetor: ");
        t = int.Parse(Console.ReadLine());

        double[] vetor = new double[t];

        lerVetor(vetor);

        Console.Write("Dentre esses valores: ");
        mostrarVetor(vetor);

        Console.WriteLine("|");

        Console.WriteLine($"O menor valor digitado foi: {menorValorVetor(vetor)}.");
    }
}