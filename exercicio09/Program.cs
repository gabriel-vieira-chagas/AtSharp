using System;
using System.Globalization;
using System.IO;

class Program
{
    const string caminhoArquivo = "estoque.txt";

    static void Main(string[] args)
    {
        bool executando = true;

        static void InserirProduto()
        {
            string nome;
            int quantidade;
            double preco;

            Console.Write("Nome do produto: ");
            nome = Console.ReadLine();

            while (true)
            {
                Console.Write("Quantidade em estoque: ");
                string entrada = Console.ReadLine();
                try
                {
                    quantidade = int.Parse(entrada);
                    break;
                }
                catch
                {
                    Console.WriteLine("Digite um número inteiro válido.");
                }
            }

            while (true)
            {
                Console.Write("Preço unitário (use vírgula para casas decimais): ");
                string entrada = Console.ReadLine();
                try
                {
                    preco = double.Parse(entrada);
                    break;
                }
                catch
                {
                    Console.WriteLine("Digite um número válido para o preço.");
                }
            }

            try
            {
                using (StreamWriter sw = File.AppendText(caminhoArquivo))
                {
                    sw.WriteLine($"{nome},{quantidade},{preco.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}");
                }
                Console.WriteLine("Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar produto: " + ex.Message);
            }
        }

        static void ListarProdutos()
        {
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);

                if (linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    return;
                }

                Console.WriteLine("\n--- Produtos Cadastrados ---");

                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');

                    if (partes.Length != 3)
                    {
                        Console.WriteLine("Erro ao ler uma linha: formato inesperado.");
                        continue;
                    }

                    try
                    {
                        string nome = partes[0];
                        int quantidade = int.Parse(partes[1]);
                        double preco = double.Parse(partes[2], CultureInfo.InvariantCulture);

                        Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: R$ {preco:F2}");
                    }
                    catch
                    {
                        Console.WriteLine("Erro ao converter os dados de um produto.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            }
        }

        while (executando)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    InserirProduto();
                    break;

                case "2":
                    ListarProdutos();
                    break;

                case "3":
                    executando = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }


}






/*
// ---------- SOLUÇÃO DA LETRA A ----------
class Program
{
    // Classe Produto para armazenar os dados
    class Produto
    {
        public string Nome;
        public int Quantidade;
        public double Preco;
    }

    static void Main(string[] args)
    {
        Produto[] estoque = new Produto[5];
        int contador = 0;
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (contador >= 5)
                    {
                        Console.WriteLine("Limite de produtos atingido!");
                        break;
                    }

                    Produto novoProduto = new Produto();

                    Console.Write("Nome do produto: ");
                    novoProduto.Nome = Console.ReadLine();

                    // Validação manual da quantidade
                    while (true)
                    {
                        Console.Write("Quantidade em estoque: ");
                        string entradaQuantidade = Console.ReadLine();
                        try
                        {
                            novoProduto.Quantidade = int.Parse(entradaQuantidade);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Digite um número inteiro válido para a quantidade.");
                        }
                    }

                    // Validação manual do preço
                    while (true)
                    {
                        Console.Write("Preço unitário (use vírgula para casas decimais): ");
                        string entradaPreco = Console.ReadLine();
                        try
                        {
                            novoProduto.Preco = double.Parse(entradaPreco);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Digite um número válido para o preço.");
                        }
                    }

                    estoque[contador] = novoProduto;
                    contador++;
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;

                case "2":
                    if (contador == 0)
                    {
                        Console.WriteLine("Nenhum produto cadastrado.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Produtos Cadastrados ---");
                        for (int i = 0; i < contador; i++)
                        {
                            Console.WriteLine($"Produto: {estoque[i].Nome} | Quantidade: {estoque[i].Quantidade} | Preço: R$ {estoque[i].Preco:F2}");
                        }
                    }
                    break;

                case "3":
                    executando = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }
}
*/