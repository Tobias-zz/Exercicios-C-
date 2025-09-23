using System;

class Exercicio5
{
    static void Main()
    {
        string ftDNA;

        Console.Write("Digite a fita de DNA: ");
        ftDNA = Console.ReadLine();

        if (ftDNA.Length > 50)
        {
            Console.Write("Fita de DNA  grande");
            return;
        }


        string fitaDNAMaiuscula = ftDNA.ToUpper();

        char[] baseDNA = fitaDNAMaiuscula.ToArray();

        string baseDNA_Nova = "";


        for (int i = 0; i < baseDNA.Length; i++)
        {
            if (baseDNA[i] != 'A' && baseDNA[i] != 'C' && baseDNA[i] != 'T' && baseDNA[i] != 'G')
            {
                Console.WriteLine($"{baseDNA[i]} é uma base de DNA inválida ");
                return;
            }

            if (baseDNA[i] == 'A')
            {
                baseDNA_Nova += "T";
            }

            else if (baseDNA[i] == 'T')
            {
                baseDNA_Nova += "A";
            }
            else if (baseDNA[i] == 'C')
            {
                baseDNA_Nova += "G";
            }
            else
            {
                baseDNA_Nova += "C";
            }
        }

        Console.WriteLine(baseDNA_Nova);

    }
}