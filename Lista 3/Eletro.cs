using System;

namespace cadastroEletro
{
    class Eletro
    {
        static void carregarDados(List<Eletro> listadeEletro, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');
                    Eletro eletro = new Eletro();
                    eletro.nome = campos[0];
                    eletro.potencia = double.Parse(campos[1]);
                    eletro.tempoMedio = double.Parse(campos[2]);
                    listadeEletro.Add(eletro);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");
        }

        static void mostrarEletros(List<Eletro> listadeEletros)
        {
            for (int i = 0; i < listadeEletros.Count; i++)
            {
                Console.WriteLine($"--- {i + 1}° Eletrodoméstico ---");
                Console.WriteLine($"Nome: {listadeEletros[i].nome}");
                Console.WriteLine($"Potência: {listadeEletros[i].potencia} kW");
                Console.WriteLine($"Uso Diário: {listadeEletros[i].tempoMedio}");
            }
        }

        static void buscarEletro(List<Eletro> listadeEletros)
        {
            Console.Write("Buscar Eletro: ");
            string busca = Console.ReadLine();
            bool achou = false;

            foreach (Eletro e in listadeEletros)
            {
                if (e.nome.ToUpper().Contains(busca.ToUpper()))
                {
                    Console.WriteLine($"Nome: {e.nome}");
                    Console.WriteLine($"Potência: {e.potencia} kW");
                    Console.WriteLine($"Uso Diário: {e.tempoMedio}");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"nenhum eletrodomésitco \"{busca}\" foi encontrado.");
        }

        static void buscarEletroGasto(List<Eletro> listadeEletros)
        {
            Console.Write("Valor Máximo de Consumo(Kw/h): ");
            double busca = double.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Eletro e in listadeEletros)
            {
                double custoKw = e.potencia * e.tempoMedio;
                if (busca < custoKw)
                {
                    Console.WriteLine($"Nome: {e.nome}");
                    Console.WriteLine($"Potência: {e.potencia} kW");
                    Console.WriteLine($"Uso Diário: {e.tempoMedio}");
                    Console.WriteLine($"Custo Kw/h: {custoKw:F1}");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"Nenhum eletrodoméstico gasta mais que {busca:F1} Kw/h");
        }

        static void buscarEletroGastoReais(List<Eletro> listadeEletros)
        {
            Console.Write("Preço do Kw/h: R$ ");
            double preco = double.Parse(Console.ReadLine());

            foreach (Eletro e in listadeEletros)
            {
                double custoKw = e.potencia * e.tempoMedio;
                double precoKw = custoKw * preco;

                Console.WriteLine();
                Console.WriteLine($"Nome: {e.nome}");
                Console.WriteLine(
                    $"Consumo (Diário / Mensal): {custoKw:F1} Kw/dia / {(custoKw * 30):F1} Kw/mês"
                );
                Console.WriteLine(
                    $"Gasto R$ (Diário / Mensal): R$ {precoKw:F2} / R$ {(precoKw * 30):F2}"
                );
            }
        }

        static int menu()
        {
            Console.WriteLine("1 - Mostrar Eletrodomésticos");
            Console.WriteLine("2 - Buscar Eletrodomésitco");
            Console.WriteLine("3 - Buscar Eletro pelo Gasto");
            Console.WriteLine("4 - Mostrar Consumo Diário e Mensal em kW e R$");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            int op = int.Parse(Console.ReadLine());

            return op;
        }

        static void Main()
        {
            List<Eletro> listadeEletros = new List<Eletro>();
            carregarDados(listadeEletros, "listaEletros.txt");
            int op;

            do
            {
                op = menu();

                switch (op)
                {
                    case 1:
                        mostrarEletros(listadeEletros);
                        break;
                    case 2:
                        buscarEletro(listadeEletros);
                        break;
                    case 3:
                        buscarEletroGasto(listadeEletros);
                        break;
                    case 4:
                        buscarEletroGastoReais(listadeEletros);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (op != 0);
        }
    }
}