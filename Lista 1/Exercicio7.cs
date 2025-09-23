using System;

class Exercicio7
{
    static void Main()
    {
        int tamanhoVetor;

        Console.Write("Digite o tamanho dos Vetores: ");
        tamanhoVetor = int.Parse(Console.ReadLine());

        int[] vetor1 = new int[tamanhoVetor];
        int[] vetor2 = new int[tamanhoVetor];
        int[] vetor3 = new int[tamanhoVetor];

        Random rnd = new Random();

        for (int i = 0; i < tamanhoVetor; i++)
        {
            int random1 = rnd.Next(1, 11);
            int random2 = rnd.Next(1, 11);
            vetor1[i] = random1;
            vetor2[i] = random2;

            vetor3[i] = vetor1[i] * vetor2[i];
        }

        Console.WriteLine("-------- 1 Vetor --------");
        for (int i = 0; i < tamanhoVetor; i++)
        {
            Console.Write(vetor1[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("-------- 2 Vetor --------");
        for (int i = 0; i < tamanhoVetor; i++)
        {
            Console.Write(vetor2[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("-------- Vetor Final --------");
        for (int i = 0; i < tamanhoVetor; i++)
        {
            Console.Write(vetor3[i] + " ");
        }
        
    }
}