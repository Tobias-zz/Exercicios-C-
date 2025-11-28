using System;
using MinhaBiblioteca;

class exercicio11
{

    public static void escreverMatriz(int[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        Console.WriteLine("mapa do Tesouro (Quantidade de Moedas em Cada Região): ");

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Console.Write($"{matriz[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
    static int diagonalPrincipal(int[,] matriz)
    {
        int n = matriz.GetLength(0);
        int somaDiagonalPrincipal = 0;

        for (int i = 0; i < n; i++)
        {
            somaDiagonalPrincipal += matriz[i, i];
        }

        return somaDiagonalPrincipal;
    }
    static int diagonalSecundaria(int[,] matriz)
    {
        int n = matriz.GetLength(0);
        int somaDiagonalSecundaria = 0;

        for (int i = 0; i < n; i++)
        {
            somaDiagonalSecundaria += matriz[i, n - 1 - i];
        }
        return somaDiagonalSecundaria;
    }

    static void Main()
    {
        int linhasColunas;

        Console.WriteLine("quantidade de linhas e colunas da Matriz: ");
        linhasColunas = int.Parse(Console.ReadLine());

        int[,] matriz = new int[linhasColunas, linhasColunas];

        Biblioteca.gerarMatriz(matriz);
        escreverMatriz(matriz);
        Console.WriteLine();
        Console.WriteLine($"Soma da Diagonal Principal: {diagonalPrincipal(matriz)}");
        Console.WriteLine($"Soma da Diagonal Secundária: {diagonalSecundaria(matriz)}");
        Console.WriteLine();

        if (diagonalPrincipal(matriz) > diagonalSecundaria(matriz))
        {
            Console.WriteLine("O maior tesouro está na diagonal principal, vamos para lá!");
        }
        else if (diagonalPrincipal(matriz) < diagonalSecundaria(matriz))
        {
            Console.WriteLine("O maior tesouro está na diagonal secundária, vamos para lá!");
        }
        else
        {
            Console.WriteLine("Ambas as diagonais tem o mesmo tesouro, pode ir para quer uma!");
        }
    }
}