using System;
using System.Globalization;

namespace cadastroGado
{
    class programGados
    {
        static void carregarDados(
            List<Gado> listadeGados,
            string nomeArquivoDados,
            string nomeArquivoDatas
        )
        {
            // Carrega dados principais (codigo, leite, alim)
            if (File.Exists(nomeArquivoDados))
            {
                string[] linhas = File.ReadAllLines(nomeArquivoDados);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');

                    Gado gado = new Gado();
                    gado.codigo = int.Parse(campos[0]);
                    gado.leite = double.Parse(campos[1]);
                    gado.alim = double.Parse(campos[2]);
                    listadeGados.Add(gado);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine($"Arquivo '{nomeArquivoDados}' não encontrado :(");

            // Carrega datas associadas (se existir o arquivo de datas)
            if (File.Exists(nomeArquivoDatas))
            {
                string[] linhas = File.ReadAllLines(nomeArquivoDatas);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');

                    int idBusca = int.Parse(campos[0]);
                    Gado gadoEncontrado = null;

                    foreach (Gado gado in listadeGados)
                    {
                        if (gado.codigo == idBusca)
                        {
                            gadoEncontrado = gado;
                            break;
                        }
                    }

                    if (gadoEncontrado != null)
                    {
                        Data data = new Data();
                        data.mes = campos[1];
                        data.ano = int.Parse(campos[2]);

                        gadoEncontrado.data = data;
                    }
                }
                Console.WriteLine("Dados de nascimento carregados com sucesso!");
            }
            else
            {
                Console.WriteLine(
                    $"Arquivo '{nomeArquivoDatas}' não encontrado (será criado ao salvar)."
                );
            }
        }

        static void salvarDados(
            List<Gado> listadeGados,
            string nomeArquivoDados,
            string nomeArquivoDatas
        )
        {
            // Salva dados principais
            using (StreamWriter writer = new StreamWriter(nomeArquivoDados))
            {
                foreach (Gado gado in listadeGados)
                {
                    writer.WriteLine($"{gado.codigo},{gado.leite},{gado.alim},{gado.abate}");
                }
            }
            Console.WriteLine($"Dados principais salvos em '{nomeArquivoDados}'");

            // Salva datas separadas
            using (StreamWriter writer = new StreamWriter(nomeArquivoDatas))
            {
                foreach (Gado gado in listadeGados)
                {
                    if (gado.data != null)
                    {
                        writer.WriteLine($"{gado.codigo},{gado.data.mes},{gado.data.ano}");
                    }
                }
            }
            Console.WriteLine($"Dados de datas salvos em '{nomeArquivoDatas}'");
        }

        static int idadeGado(Gado g, int mesAtual)
        {
            int idade = 0;

            if (g.data != null)
            {
                Data d = g.data;
                int mes = d.mes.ToUpper().Trim() switch
                {
                    "JANEIRO" => 1,
                    "FEVEREIRO" => 2,
                    "MARÇO" => 3,
                    "ABRIL" => 4,
                    "MAIO" => 5,
                    "JUNHO" => 6,
                    "JULHO" => 7,
                    "AGOSTO" => 8,
                    "SETEMBRO" => 9,
                    "OUTUBRO" => 10,
                    "NOVEMBRO" => 11,
                    "DEZEMBRO" => 12,
                    _ => throw new ArgumentException($"Nome do mês inválido: {d.mes}"),
                };

                if (mes <= mesAtual)
                    idade = 2025 - d.ano;
                else if (mes > mesAtual)
                    idade = 2024 - d.ano;
            }

            return idade;
        }

        static void gadosAbate(List<Gado> listadeGados, int mesAtual)
        {
            foreach (Gado g in listadeGados)
            {
                int idade = idadeGado(g, mesAtual);
                if (idade > 5 || g.leite < 40)
                    g.abate = true;
                else
                    g.abate = false;
            }
        }

        static double leiteSemanal(List<Gado> listadeGados)
        {
            double totalLeite = 0.0;

            foreach (Gado g in listadeGados)
            {
                totalLeite += g.leite;
            }

            return totalLeite;
        }

        static double alimSemanal(List<Gado> listadeGados)
        {
            double totalAlim = 0.0;

            foreach (Gado g in listadeGados)
            {
                totalAlim += g.alim;
            }

            return totalAlim;
        }

        static void listaAbate(List<Gado> listadeGados, int mesAtual)
        {
            Console.WriteLine("--- Gados para Abate ---");
            string motivo = "";

            foreach (Gado g in listadeGados)
            {
                if (g.abate == true)
                {
                    int idade = idadeGado(g, mesAtual);

                    if (g.leite < 40 && idade > 5)
                        motivo = "Pouca produção de leite e idade avançada";
                    else if (g.leite < 40)
                        motivo = "Pouca produção de leite";
                    else if (idade > 5)
                        motivo = "Idade avançada";

                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Gódigo: {g.codigo}");
                    Console.WriteLine($"Motivo: {motivo}");
                }
            }
        }

        static void Main()
        {
            List<Gado> listadeGados = new List<Gado>();
            carregarDados(listadeGados, "listaGados.txt", "listaNasciGados.txt");
            Console.Write("Mês Atual(numérico): ");
            int mesAtual = int.Parse(Console.ReadLine());
            gadosAbate(listadeGados, mesAtual);
            Console.Clear();

            int op;

            do
            {
                op = menu();

                switch (op)
                {
                    case 1:
                        Console.WriteLine(
                            $"total de Leite produzido na semana: {leiteSemanal(listadeGados):F1} Litros"
                        );
                        break;
                    case 2:
                        Console.WriteLine(
                            $"Total de Alimento consumido na semana: {alimSemanal(listadeGados):F1} KG"
                        );
                        break;
                    case 3:
                        listaAbate(listadeGados, mesAtual);
                        break;
                    case 0:
                        salvarDados(listadeGados, "listaGados.txt", "listaNasciGados.txt");
                        Console.WriteLine("Saindo...");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (op != 0);
        }

        static int menu()
        {
            Console.WriteLine("--- Sistema de Controle de Gados ---");
            Console.WriteLine("1 - Total de Leite Produzido Semanalmente");
            Console.WriteLine("2 - Total de Alimento Consumido Semanalmente");
            Console.WriteLine("3 - Gados para Abate");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            int op = int.Parse(Console.ReadLine());

            return op;
        }
    }
}