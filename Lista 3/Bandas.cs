using System;

namespace cadastroBandas
{
    class Bandas
    {
        static void carregarDados(List<Banda> listadeBandas, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');
                    Banda banda = new Banda();
                    banda.nome = campos[0];
                    banda.tipo = campos[1];
                    banda.integrantes = int.Parse(campos[2]);
                    banda.rank = int.Parse(campos[3]);
                    listadeBandas.Add(banda);
                }
                Console.WriteLine("dados carregados com sucesso!");
            }
            else
                Console.WriteLine("arquivo não encontrado :(");
        }

        static void salvarDados(List<Banda> listadeBandas, string nomeArquivo)
        {
            StreamWriter writer = new StreamWriter(nomeArquivo);

            foreach (Banda banda in listadeBandas)
            {
                writer.WriteLine($"{banda.nome},{banda.tipo},{banda.integrantes},{banda.rank}");
            }

            Console.WriteLine("dados salvos com sucesso!");
            writer.Dispose();
        }

        static void cadastrarBanda(List<Banda> listadeBandas)
        {
            Banda novaBanda = new Banda();

            Console.Write("Nome da Banda: ");
            novaBanda.nome = Console.ReadLine();
            Console.Write("Gênero Musical: ");
            novaBanda.tipo = Console.ReadLine();
            Console.Write("Integrantes: ");
            novaBanda.integrantes = int.Parse(Console.ReadLine());
            Console.Write("Ranking: ");
            novaBanda.rank = int.Parse(Console.ReadLine());

            listadeBandas.Add(novaBanda);
        }

        static void mostrarBandas(List<Banda> listadeBandas)
        {
            for (int i = 0; i < listadeBandas.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"--- Banda {i + 1} ---");
                Console.WriteLine($"Nome: {listadeBandas[i].nome}");
                Console.WriteLine($"Gênero: {listadeBandas[i].tipo}");
                Console.WriteLine($"Integrantes: {listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listadeBandas[i].rank}°");
            }
        }

        static void buscarBanda(List<Banda> listadeBandas)
        {
            Console.Write("nome da Banda: ");
            string busca = Console.ReadLine();
            bool achou = false;

            foreach (Banda b in listadeBandas)
            {
                if (b.nome.ToUpper().Contains(busca.ToUpper()))
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- {b.nome.ToUpper()} ---");
                    Console.WriteLine($"gênero: {b.tipo}");
                    Console.WriteLine($"integrantes: {b.integrantes}");
                    Console.WriteLine($"Ranking: {b.rank}°");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"nenhuma banda com o nome {busca} foi encontrada.");
        }

        static void buscarBandaGenero(List<Banda> listadeBandas)
        {
            Console.Write("Gênero: ");
            string busca = Console.ReadLine();
            bool achou = false;

            foreach (Banda b in listadeBandas)
            {
                if (b.tipo.ToUpper().Contains(busca.ToUpper()))
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- {b.nome.ToUpper()} ---");
                    Console.WriteLine($"Gênero: {b.tipo}");
                    Console.WriteLine($"Integrantes: {b.integrantes}");
                    Console.WriteLine($"Ranking: {b.rank}°");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"Nenhuma banda com o gênero {busca} foi encontrada.");
        }

        static void buscarBandaRank(List<Banda> listadeBandas)
        {
            Console.Write("Rank: ");
            int busca = int.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Banda b in listadeBandas)
            {
                if (b.rank == busca)
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- {b.nome.ToUpper()} ---");
                    Console.WriteLine($"Gênero: {b.tipo}");
                    Console.WriteLine($"Integrantes: {b.integrantes}");
                    Console.WriteLine($"Ranking: {b.rank}°");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"Nenhuma banda no rank {busca}° foi encontrada.");
        }

        static void editarBanda(List<Banda> listadeBandas)
        {
            Console.Write("Qual banda você quer editar(n° da banda): ");
            int posicao = int.Parse(Console.ReadLine());
            int index = posicao - 1;
            bool achou = false;

            if (index >= 0 && index <= listadeBandas.Count)
            {
                Console.Write("Novo nome(0 para manter): ");
                string novoNome = Console.ReadLine();
                if (novoNome != "0")
                    listadeBandas[index].nome = novoNome;

                Console.Write("Novo gênero(0 para manter): ");
                string novoGenero = Console.ReadLine();
                if (novoGenero != "0")
                    listadeBandas[index].tipo = novoGenero;

                Console.Write("Nova quantidade de integrantes(0 para manter): ");
                int novaQuant = int.Parse(Console.ReadLine());
                if (novaQuant != 0)
                    listadeBandas[index].integrantes = novaQuant;

                Console.Write("Novo ranking(0 para manter): ");
                int novoRank = int.Parse(Console.ReadLine());
                if (novoRank != 0)
                    listadeBandas[index].rank = novoRank;

                Console.WriteLine();
                Console.WriteLine("Banda atualizada com sucesso!");

                achou = true;
            }

            if (achou == true)
            {
                Console.WriteLine();
                Console.WriteLine($"--- {listadeBandas[index].nome.ToUpper()} ---");
                Console.WriteLine($"Gênero: {listadeBandas[index].tipo}");
                Console.WriteLine($"Integrantes: {listadeBandas[index].integrantes}");
                Console.WriteLine($"Ranking: {listadeBandas[index].rank}°");
            }

            if (achou == false)
                Console.WriteLine($"Banda no índice {posicao} não encontrada.");
        }

        static void excluirBanda(List<Banda> listadeBandas)
        {
            Console.Write("Qual banda você quer editar(n° da banda): ");
            int posicao = int.Parse(Console.ReadLine());
            int index = posicao - 1;

            if (index >= 0 && index <= listadeBandas.Count)
            {
                string nome = listadeBandas[index].nome;

                listadeBandas.RemoveAt(index);

                Console.WriteLine($"A banda {nome} foi excluida com sucesso.");
            }
            else
            {
                Console.WriteLine($"Banda no índice {posicao} não encontrada.");
            }
        }

        static int menu()
        {
            Console.WriteLine("--- Sistema de Cadastro de Bandas ---");
            Console.WriteLine("1 - Cadastrar Banda");
            Console.WriteLine("2 - Mostrar Bandas");
            Console.WriteLine("3 - Buscar Banda");
            Console.WriteLine("4 - Buscar Banda pelo Gênero");
            Console.WriteLine("5 - Buscar Banda pelo Ranking");
            Console.WriteLine("6 - Editar Banda");
            Console.WriteLine("7 - Excluir Banda");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }

        static void Main()
        {
            List<Banda> listadeBandas = new List<Banda>();
            int op;
            carregarDados(listadeBandas, "listaBandas.txt");

            do
            {
                op = menu();

                switch (op)
                {
                    case 1:
                        cadastrarBanda(listadeBandas);
                        break;
                    case 2:
                        mostrarBandas(listadeBandas);
                        break;
                    case 3:
                        buscarBanda(listadeBandas);
                        break;
                    case 4:
                        buscarBandaGenero(listadeBandas);
                        break;
                    case 5:
                        buscarBandaRank(listadeBandas);
                        break;
                    case 6:
                        mostrarBandas(listadeBandas);
                        Console.WriteLine();
                        editarBanda(listadeBandas);
                        break;
                    case 7:
                        mostrarBandas(listadeBandas);
                        Console.WriteLine();
                        excluirBanda(listadeBandas);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        salvarDados(listadeBandas, "listaBandas.txt");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (op != 0);
        }
    }
}