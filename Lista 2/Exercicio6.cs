using System;
using System.Globalization;
using MinhaBiblioteca;

class Exercicio6
{
    static int[,] SomarMatrizes(int[,] matriz1, int[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int colunas = matriz1.GetLength(1);
        int[,] resultado = new int[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                resultado[i, j] = matriz1[i, j] + matriz2[i, j];
            }
        }

        return resultado;
    }

    static void Main()
    {
        Console.WriteLine("Digite o numero de linhas: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o numero de colunas: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matriz1 = new int[n, m];
        int[,] matriz2 = new int[n, m];

        Biblioteca.gerarMatriz(matriz1);
        Biblioteca.mostrarMatriz(matriz1);

        Biblioteca.gerarMatriz(matriz2);
        Biblioteca.mostrarMatriz(matriz2);

        if (matriz1.GetLength(0) == matriz2.GetLength(0) &&
            matriz1.GetLength(1) == matriz2.GetLength(1))
        {
            int[,] resultado = SomarMatrizes(matriz1, matriz2);

            Console.WriteLine("\nMatriz resultado da soma:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(resultado[i, j] + " ");

                }
                Console.WriteLine();

            }
        }
        else
        {
            Console.WriteLine("\nAs matrizes não são da mesma ordem, não da para somar.");
        }




    }
}

