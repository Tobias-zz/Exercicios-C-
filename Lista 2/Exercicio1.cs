    using System;
    using MinhaBiblioteca;

    class Exercicio1
    {
        static int MenorValorMatriz(int[,] matriz)
        {
            int menor = matriz[0, 0];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] < menor)
                    {
                        menor = matriz[i, j];
                    }
                }
            }
            return menor;
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

            Console.WriteLine("----- Menor -----");

            Console.WriteLine(MenorValorMatriz(matriz));

        }
    }