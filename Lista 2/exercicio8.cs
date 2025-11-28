using System;
using MinhaBiblioteca;

class exercicio8
{
    static void Main()
    {
        int QuantRaios;
        int QuantLinhas = 0, QuantColunas = 0;

        Console.Write("quantidade de raios: ");
        QuantRaios = int.Parse(Console.ReadLine());

        Console.Write("quantidade de linhas e colunas: ");
        string entrada = Console.ReadLine();

        char delimitador = ' ';
        string[] partes = entrada.Split(delimitador);
        QuantLinhas = int.Parse(partes[0]);
        QuantColunas = int.Parse(partes[1]);

        int[,] mapa = new int[QuantLinhas, QuantColunas];
        int contador = 0;

        for (int i = 0; i < QuantRaios; i++)
        {
            Console.Write("coordenadas: ");
            string entrada2 = Console.ReadLine();

            char delimitador2 = ' ';
            string[] partes2 = entrada2.Split(delimitador2);
            int linha = int.Parse(partes2[0]);
            int coluna = int.Parse(partes2[1]);

            if (linha < 0 || linha >= QuantLinhas || coluna < 0 || coluna >= QuantColunas)
            {
                Console.WriteLine("coordenada incorreta!");
                i--;
                continue;
            }
            else
            {
                mapa[linha, coluna]++;
            }

            if (mapa[linha, coluna] >= 2)
            {
                contador++;
            }
        }

        Console.WriteLine(contador);
        
    }
}