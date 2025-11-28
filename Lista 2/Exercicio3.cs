using System;
using MinhaBiblioteca;

class Exercicio3
{
    static int contOcorrencia(int[,] matriz, int x)
    {
        int cont = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] == x)
                {
                    cont++;
                }
            }
        }
        return cont;
    }

    static void Main()
    {
        Console.WriteLine("Insira o numero de linhas: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Insira o numero de Colunas: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matriz = new int[n, m];

        Biblioteca.gerarMatriz(matriz);
        Biblioteca.mostrarMatriz(matriz);

        Console.WriteLine("\n Digite o x que deseja procurar: ");
        int x = int.Parse(Console.ReadLine());

        int ocorrencia = contOcorrencia(matriz, x);
        Console.WriteLine($"O numero {x} aparece {ocorrencia} vezes na matriz");
    }
}