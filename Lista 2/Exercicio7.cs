using System;
using System.Collections;
using System.Reflection.Metadata;
using MinhaBiblioteca;

class Exercicio7
{
       static Random rand = new Random();


    static void ImprimirMatriz(double[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int cols = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matriz[i, j].ToString("F2") + "\t");
            }
            Console.WriteLine();
        }
    }

        static double[,] GerarMatriz(int n, int m)
    {
        double[,] matriz = new double[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // gera número real entre 0 e 100
                matriz[i, j] = rand.NextDouble() * 100;
            }
        }
        return matriz;
    }

    static double[,] SomarMatrizes(double[,] matriz1, double[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int cols = matriz1.GetLength(1);
        double[,] resultado = new double[linhas, cols];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultado[i, j] = matriz1[i, j] + matriz2[i, j];
            }
        }

        return resultado;
    }

    static double[,] SubMatrizes(double[,] matriz1, double[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int cols = matriz1.GetLength(1);
        double[,] resultado = new double[linhas, cols];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultado[i, j] = matriz2[i, j] - matriz1[i, j];
            }
        }

        return resultado;
    }

    static void AdicionarConstante(double[,] matriz, double constante)
    {
        int linhas = matriz.GetLength(0);
        int cols = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matriz[i, j] += constante;
            }
        }
    }


    static void Main()
    {Console.Write("Digite o número de linhas: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Digite o número de colunas: ");
        int m = int.Parse(Console.ReadLine());

        double[,] matriz1 = GerarMatriz(n, m);
        double[,] matriz2 = GerarMatriz(n, m);

        Console.WriteLine("\nMatriz 1:");
        ImprimirMatriz(matriz1);

        Console.WriteLine("\nMatriz 2:");
        ImprimirMatriz(matriz2);

        char opcao;

        do
        {
            Console.WriteLine("\nMENU DE OPÇÕES");
            Console.WriteLine("a) Somar as duas matrizes");
            Console.WriteLine("b) Subtrair a primeira matriz da segunda");
            Console.WriteLine("c) Adicionar uma constante às duas matrizes");
            Console.WriteLine("d) Imprimir as matrizes");
            Console.WriteLine("e) Sair");
            Console.Write("Escolha uma opção: ");
            opcao = char.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 'a':
                    Console.WriteLine("\nResultado da soma:");
                    double[,] soma = SomarMatrizes(matriz1, matriz2);
                    ImprimirMatriz(soma);
                    break;

                case 'b':
                    Console.WriteLine("\nResultado da subtração (matriz2 - matriz1):");
                    double[,] sub = SubMatrizes(matriz1, matriz2);
                    ImprimirMatriz(sub);
                    break;

                case 'c':
                    Console.Write("\nDigite a constante: ");
                    double constante = double.Parse(Console.ReadLine());
                    AdicionarConstante(matriz1, constante);
                    AdicionarConstante(matriz2, constante);
                    Console.WriteLine("Constante adicionada às duas matrizes!");
                    break;

                case 'd':
                    Console.WriteLine("\nMatriz 1:");
                    ImprimirMatriz(matriz1);
                    Console.WriteLine("\nMatriz 2:");
                    ImprimirMatriz(matriz2);
                    break;

                case 'e':
                    Console.WriteLine("Encerrando...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        } while (opcao != 'e');
    }
}
