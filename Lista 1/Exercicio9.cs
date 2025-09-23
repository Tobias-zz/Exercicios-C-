using System;

class Exercicio9
{
    static void Main()
    {
        Console.Write("Digite algum texto: ");
        string frase = Console.ReadLine();

        char[] fraseChar = frase.ToCharArray();

        int tamanho = frase.Length;

        Array.Reverse(fraseChar);

        Console.WriteLine("Texto invertido: " + new string(fraseChar));
        Console.WriteLine("Tamanho do vetor: " + tamanho);
    }
}