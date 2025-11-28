using System;
using System.Drawing;
using MinhaBiblioteca;

class Exercicio9
{

    static double somarMatriz(int[,] matriz)
    {
        double soma = 0;
        int linhas = matriz.GetLength(0);
        int cols = matriz.GetLength(1);
        for (int i = 0; i < linhas; i++)
            for (int j = 0; j < cols; j++)
                soma += matriz[i, j];

        return soma;
    }
    static void Main()
    {
        int linhas, cols;
        int xi, xf, yi, yf;
        int quantidadeRedes;
        double areaOcupada, percentualOcupado;
        Console.Write("Entre com a quantidade de linhas e colunas:");
        linhas = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());
        int[,] matrixMar = new int[linhas, cols];
        Biblioteca.mostrarMatriz(matrixMar);

        Console.Write("Entre com a quantidade de redes:");
        quantidadeRedes = int.Parse(Console.ReadLine());

        for (int cont = 1; cont <= quantidadeRedes; cont++)
        {

            Console.WriteLine($"--- Entre com as coordenadas da rede {cont} ---");
            Console.WriteLine("Xi e Xf");
            xi = int.Parse(Console.ReadLine());
            xf = int.Parse(Console.ReadLine());

            Console.WriteLine("Yi e Yf");
            yi = int.Parse(Console.ReadLine());
            yf = int.Parse(Console.ReadLine());

            for (int i = xi; i <= xf; i++)
                for (int j = yi; j <= yf; j++)
                    matrixMar[i, j] = 1;

        }
        Biblioteca.mostrarMatriz(matrixMar);
        areaOcupada = somarMatriz(matrixMar);
        Console.WriteLine($"Area ocupada: {areaOcupada:F0}");
        percentualOcupado = areaOcupada / (linhas * cols) * 100;
        Console.WriteLine($"Percentual ocupado: {percentualOcupado:F4}%");




    }

}