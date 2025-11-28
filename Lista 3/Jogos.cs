using System;

namespace cadastroJogo
{
    class Jogos
    {
        static void carregarDados(List<Jogo> listadeJogos, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');

                    Jogo jogo = new Jogo();
                    jogo.nome = campos[0];
                    jogo.console = campos[1];
                    jogo.rank = int.Parse(campos[2]);
                    listadeJogos.Add(jogo);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");
        }

        static void CarregarEmprestimos(List<Jogo> listadeJogos, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');

                    string tituloBusca = campos[0];
                    Jogo jogoEncontrado = null;

                    foreach (Jogo jogo in listadeJogos)
                    {
                        if (jogo.nome.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
                        {
                            jogoEncontrado = jogo;
                            break;
                        }
                    }

                    if (jogoEncontrado != null)
                    {
                        Emprestimo emprestimo = new Emprestimo();
                        emprestimo.data = DateOnly.Parse(campos[1]);
                        emprestimo.nomePessoa = campos[2].Trim();
                        emprestimo.emprestado = bool.Parse(campos[3]);

                        jogoEncontrado.listadeEmprestimos.Add(emprestimo);
                    }
                }
                Console.WriteLine("Dados de Empréstimos carregados com sucesso!");
            }
            else
            {
                Console.WriteLine(
                    "Arquivo 'emprestimos.txt' não encontrado (será criado ao salvar)."
                );
            }
        }

        static void salvarDados(List<Jogo> listadeJogos, string nomeArquivo)
        {
            StreamWriter writer = new StreamWriter(nomeArquivo);

            foreach (Jogo jogo in listadeJogos)
            {
                writer.WriteLine($"{jogo.nome},{jogo.console},{jogo.rank}");
            }

            Console.WriteLine("Dados de Jogos salvos com sucesso!");
            writer.Dispose();
        }

        static void SalvarEmprestimos(List<Jogo> listadeJogos, string nomeArquivo)
        {
            StreamWriter writer = new StreamWriter(nomeArquivo);

            foreach (Jogo jogo in listadeJogos)
            {
                foreach (Emprestimo emprestimo in jogo.listadeEmprestimos)
                {
                    writer.WriteLine(
                        $"{jogo.nome},{emprestimo.data},{emprestimo.nomePessoa},{emprestimo.emprestado}"
                    );
                }
            }

            Console.WriteLine("Dados de Empréstimos salvos com sucesso!");
            writer.Dispose();
        }

        static Emprestimo obterUltimoEmprestimo(Jogo j)
        {
            if (j.listadeEmprestimos.Count == 0)
                return null;

            Emprestimo maisNovo = j.listadeEmprestimos[0];
            foreach (Emprestimo e in j.listadeEmprestimos)
            {
                if (e.data > maisNovo.data)
                    maisNovo = e;
            }

            return maisNovo;
        }

        static void mostrarJogos(List<Jogo> listadeJogos)
        {
            foreach (Jogo j in listadeJogos)
            {
                string statusTexto = "Não";

                Emprestimo emprestimo = obterUltimoEmprestimo(j);

                if (emprestimo != null && emprestimo.emprestado == true)
                    statusTexto = "Sim";

                Console.WriteLine();
                Console.WriteLine($"--- {j.nome} ---");
                Console.WriteLine($"Console: {j.console}");
                Console.WriteLine($"Rank: {j.rank}");
                Console.WriteLine($"Emprestado: {statusTexto}");
            }
        }

        static void buscarJogo(List<Jogo> listadeJogos)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Console");
            Console.Write("Buscar por: ");
            int op = int.Parse(Console.ReadLine());

            bool achou = false;

            if (op == 1)
            {
                Console.WriteLine();
                Console.Write("Nome: ");
                string busca = Console.ReadLine();

                foreach (Jogo j in listadeJogos)
                {
                    string statusTexto = "Não";

                    Emprestimo emprestimo = obterUltimoEmprestimo(j);

                    if (emprestimo != null && emprestimo.emprestado == true)
                        statusTexto = "Sim";

                    if (j.nome.ToUpper().Contains(busca.ToUpper()))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"--- {j.nome} ---");
                        Console.WriteLine($"Console: {j.console}");
                        Console.WriteLine($"Rank: {j.rank}");
                        Console.WriteLine($"Emprestado: {statusTexto}");

                        achou = true;
                    }
                }

                if (achou == false)
                    Console.WriteLine($"O jogo {busca} não está na nossa biblioteca de jogos");
            }
            else if (op == 2)
            {
                Console.Write("Console: ");
                string busca = Console.ReadLine();

                foreach (Jogo j in listadeJogos)
                {
                    if (j.console.ToUpper().Contains(busca.ToUpper()))
                    {
                        string statusTexto = "Não";

                        Emprestimo emprestimo = obterUltimoEmprestimo(j);

                        if (emprestimo != null && emprestimo.emprestado == true)
                            statusTexto = "Sim";

                        Console.WriteLine();
                        Console.WriteLine($"--- {j.nome} ---");
                        Console.WriteLine($"Console: {j.console}");
                        Console.WriteLine($"Rank: {j.rank}");
                        Console.WriteLine($"Emprestado: {statusTexto}");

                        achou = true;
                    }
                }

                if (achou == false)
                    Console.WriteLine($"O console {busca} não está na nossa bibliteca de consoles");
            }
        }

        static void fazerEmprestimo(List<Jogo> listadeJogos)
        {
            Console.WriteLine();
            Console.WriteLine("Qual jogo deseja fazer o emprestimo: ");
            string busca = Console.ReadLine();

            bool foiEncontrado = false;

            foreach (Jogo j in listadeJogos)
            {
                if (j.nome.ToUpper().Trim().Equals(busca.ToUpper().Trim()))
                {
                    foiEncontrado = true;
                    bool estaEmprestado = false;

                    Emprestimo emprestimo = obterUltimoEmprestimo(j);

                    if (emprestimo != null && emprestimo.emprestado == true)
                        estaEmprestado = true;

                    Console.WriteLine();

                    if (estaEmprestado == true)
                    {
                        Console.WriteLine($"O jogo {busca} já está emprestado");
                        return;
                    }
                    else
                    {
                        Console.Write("Nome do cliente: ");
                        string nome = Console.ReadLine();

                        DateOnly dataDoEmprestimo;
                        bool dataConverteu = false;

                        do
                        {
                            Console.Write("Data do Emprestimo (ex: 13/11/2025): ");
                            string dataString = Console.ReadLine();

                            dataConverteu = DateOnly.TryParse(dataString, out dataDoEmprestimo);

                            if (dataConverteu == false)
                            {
                                Console.WriteLine("Data inválida, tente novamente");
                            }
                        } while (dataConverteu == false);

                        Emprestimo novoEmprestimo = new Emprestimo();

                        novoEmprestimo.data = dataDoEmprestimo;
                        novoEmprestimo.nomePessoa = nome;
                        novoEmprestimo.emprestado = true;

                        j.listadeEmprestimos.Add(novoEmprestimo);

                        Console.WriteLine("Empréstimo registrado com sucesso!");
                        return;
                    }
                }
            }
            if (foiEncontrado == false)
                Console.WriteLine($"O jogo {busca} não foi encontrado na nossa biblioteca");
        }

        static void devolverEmprestimo(List<Jogo> listadeJogos)
        {
            Console.WriteLine();
            Console.Write("Jogo para Devolução: ");
            string jogoDevol = Console.ReadLine();

            Jogo jogoEncontrado = null;
            Emprestimo ultimoEmprestimo = null;
            bool estaEmprestado = false;

            foreach (Jogo j in listadeJogos)
            {
                if (j.nome.ToUpper().Trim().Equals(jogoDevol.ToUpper().Trim()))
                {
                    jogoEncontrado = j;

                    ultimoEmprestimo = obterUltimoEmprestimo(j);

                    if (ultimoEmprestimo != null && ultimoEmprestimo.emprestado == true)
                    {
                        estaEmprestado = true;
                    }

                    break;
                }
            }

            if (jogoEncontrado == null)
            {
                Console.WriteLine($"O jogo {jogoDevol} não foi encontrado.");
                return;
            }

            if (estaEmprestado == true)
            {
                Console.WriteLine("Você tem certeza que deseja devolver (S/N): ");
                ConsoleKeyInfo tecla = Console.ReadKey();
                char certeza = char.ToUpper(tecla.KeyChar);

                Console.WriteLine();

                if (certeza == 'S')
                {
                    ultimoEmprestimo.emprestado = false;
                    Console.WriteLine("Devolução confirmada. Registrando...");
                }
                else
                {
                    Console.WriteLine("Devolução cancelada.");
                }
            }
            else
                Console.WriteLine($"O jogo {jogoDevol} não está emprestado");
        }

        static void mostrarJogosEmprestados(List<Jogo> listadeJogos)
        {
            foreach (Jogo j in listadeJogos)
            {
                bool estaEmprestado = false;

                Emprestimo emprestimo = obterUltimoEmprestimo(j);

                if (emprestimo != null && emprestimo.emprestado == true)
                    estaEmprestado = true;

                if (estaEmprestado == true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- Jogo: {j.nome} ---");
                    Console.WriteLine($"Emprestado para: {emprestimo.nomePessoa}");
                }
            }
        }

        static void Main()
        {
            List<Jogo> listadeJogos = new List<Jogo>();
            carregarDados(listadeJogos, "listaJogos.txt");
            CarregarEmprestimos(listadeJogos, "listaEmprestimos.txt");

            int op;

            do
            {
                op = menu();

                switch (op)
                {
                    case 1:
                        mostrarJogos(listadeJogos);
                        break;
                    case 2:
                        buscarJogo(listadeJogos);
                        break;
                    case 3:
                        fazerEmprestimo(listadeJogos);
                        break;
                    case 4:
                        devolverEmprestimo(listadeJogos);
                        break;
                    case 5:
                        mostrarJogosEmprestados(listadeJogos);
                        break;
                    case 0:
                        salvarDados(listadeJogos, "listaJogos.txt");
                        SalvarEmprestimos(listadeJogos, "listaEmprestimos.txt");
                        Console.WriteLine("Saindo...");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (op != 0);
        }

        static int menu()
        {
            Console.WriteLine(" Sistema de Cadastro de Jogos ");
            Console.WriteLine("1 - Listar Jogos");
            Console.WriteLine("2 - Buscar Jogo");
            Console.WriteLine("3 - Fazer Emprestimo");
            Console.WriteLine("4 - Devolver Emprestimo");
            Console.WriteLine("5 - Listar Jogos Emprestados");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
    }
}