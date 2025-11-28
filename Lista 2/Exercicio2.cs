using System;
using MinhaBiblioteca;

class Exercicio2
{
    static int MaiorValorMatriz(int[,] matriz)
    {
        int maior = matriz[0, 0];

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] > maior)
                {
                    maior = matriz[i, j];
                }
            }
        }
        return maior;
    }

    static void Main()
    {
        Console.Write("Digite o número de linhas: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Digite o número de colunas: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matriz = new int[n, m];

        Biblioteca.gerarMatriz(matriz);
        Biblioteca.mostrarMatriz(matriz);

        Console.WriteLine("----- Maior -----");

        Console.WriteLine(MaiorValorMatriz(matriz));

    }
}