using System;

namespace cadastroLivros
{
    class Livros
    {
        static void carregarDados(List<Livro> listadeLivros, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');
                    Livro livro = new Livro();
                    livro.titulo = campos[0];
                    livro.autor = campos[1];
                    livro.ano = int.Parse(campos[2]);
                    livro.prateleira = int.Parse(campos[3]);
                    listadeLivros.Add(livro);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");
        }

        static void salvarDados(List<Livro> listadeLivros, string nomeArquivo)
        {
            StreamWriter writer = new StreamWriter(nomeArquivo);

            foreach (Livro livro in listadeLivros)
            {
                writer.WriteLine($"{livro.titulo},{livro.autor},{livro.ano},{livro.prateleira}");
            }

            Console.WriteLine("Dados salvos com sucesso!");
            writer.Dispose();
        }

        static void cadastrarLivro(List<Livro> listadeLivros)
        {
            Livro novoLivro = new Livro();

            Console.Write("Título: ");
            novoLivro.titulo = Console.ReadLine();
            Console.Write("Autor: ");
            novoLivro.autor = Console.ReadLine();
            Console.Write("Ano: ");
            novoLivro.ano = int.Parse(Console.ReadLine());
            Console.Write("Prateleira: ");
            novoLivro.prateleira = int.Parse(Console.ReadLine());

            listadeLivros.Add(novoLivro);
        }

        static void mostrarLivros(List<Livro> listadeLivros)
        {
            for (int i = 0; i < listadeLivros.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"--- Livro {i + 1} ---");
                Console.WriteLine($"Título: {listadeLivros[i].titulo}");
                Console.WriteLine($"Autor: {listadeLivros[i].autor}");
                Console.WriteLine($"Ano: {listadeLivros[i].ano}");
                Console.WriteLine($"Prateleira: {listadeLivros[i].prateleira}");
            }
        }

        static void buscarLivros(List<Livro> listadeLivros)
        {
            Console.Write("Buscar livro: ");
            string busca = Console.ReadLine();
            bool achou = false;

            foreach (Livro l in listadeLivros)
            {
                if (l.titulo.ToUpper().Contains(busca.ToUpper()))
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- {l.titulo.ToUpper()} ---");
                    Console.WriteLine($"Prateleira: {l.prateleira}");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine("Nenhum livro encontrado.");
        }

        static void buscarLivroAno(List<Livro> listadeLivros)
        {
            Console.Write("Buscar Ano: ");
            int ano = int.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Livro l in listadeLivros)
            {
                if (l.ano < ano)
                {
                    Console.WriteLine();
                    Console.WriteLine($"--- {l.titulo.ToUpper()} ---");
                    Console.WriteLine($"Autor: {l.autor}");
                    Console.WriteLine($"Ano: {l.ano}");
                    Console.WriteLine($"Prateleira: {l.prateleira}");

                    achou = true;
                }
            }

            if (achou == false)
                Console.WriteLine($"Nenhum livro no sitema é mais novo que {ano}.");
        }

        static int menu()
        {
            Console.WriteLine("--- Sistema de Cadastro de Livros ---");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Mostrar Livros");
            Console.WriteLine("3 - Buscar Livro");
            Console.WriteLine("4 - Buscar Livro por Ano");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }

        static void Main()
        {
            List<Livro> listadeLivros = new List<Livro>();
            carregarDados(listadeLivros, "listaLivros.txt");
            int op;

            do
            {
                op = menu();

                switch (op)
                {
                    case 1:
                        cadastrarLivro(listadeLivros);
                        break;
                    case 2:
                        mostrarLivros(listadeLivros);
                        break;
                    case 3:
                        buscarLivros(listadeLivros);
                        break;
                    case 4:
                        buscarLivroAno(listadeLivros);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        salvarDados(listadeLivros, "listaLivros.txt");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (op != 0);
        }
    }
}