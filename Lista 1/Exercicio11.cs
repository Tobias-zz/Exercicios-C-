using System;

class Exercicio11
{
    static string decodificar(string fraseCodificada)
    {
        char[] fraseCodificada_char = fraseCodificada.ToArray();
        string fraseDecodificada_char = "";

        for (int i = 0; i < fraseCodificada_char.Length; i++)
        {
            if (fraseCodificada_char[i] == 'p')
            {
                if (i + 1 < fraseCodificada.Length)
                {
                    fraseDecodificada_char += fraseCodificada_char[i + 1];
                    i++;
                }
            }
            else
            {
                fraseDecodificada_char += fraseCodificada_char[i];
            }
        }

        string fraseDecodificada = new string(fraseDecodificada_char);

        return fraseDecodificada;
    }

    static void Main()
    {
        string frase_codificada;

        Console.Write("Frase codificada: ");
        frase_codificada = Console.ReadLine();

        Console.WriteLine("Frase decodificada: " + decodificar(frase_codificada));
    }
}