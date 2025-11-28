using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
using MinhaBiblioteca;

class Exercicio5
{
    static void Main()
    {
        Console.WriteLine("Digite a ordem da matriz (até 100): ");
        int n = int.Parse(Console.ReadLine());

        if (n > 100 || n <= 0)
        {
            Console.WriteLine("A ordem deve ser entre 1 a 100! ");
            return;
        }
        

        int[,] matriz = new int[n, n];

        Biblioteca.gerarMatriz(matriz);
        Biblioteca.mostrarMatriz(matriz);

        Console.WriteLine("\nDiagonal secundaria: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(matriz[i, n - 1 - i] + " ");

        }
        Console.WriteLine();
        
    }
}