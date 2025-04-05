using System;
using System.Globalization;
using System.IO;

class Program
{
    const string caminhoArquivo = @"D:\\INFNET\estoque.txt"; //Cria o caminho para o txt

    static void Main(string[] args)
    {
        bool executando = true; //Inicializa a variável de execução do menu
        int contador = 0;

        static void InserirProduto() //Cria método pra inserir o produto
        {
            string nome; //Inicializa o nome do produto
            int quantidade; // Inicializa quantidade de estoque
            double preco; // Inicializa o preço do produto

            Console.Write("Nome do produto: "); //Requisita nome
            nome = Console.ReadLine(); //Captura nome

            while (true) //While com true pois o break está nas condições
            {
                try //Tenta capturar dado válido até o usuário inserir corretamente
                {
                    Console.Write("Quantidade em estoque: "); //Requisita a quantidade
                    int entradaQtd = Convert.ToInt32(Console.ReadLine());
                    quantidade = entradaQtd; //Armazena a quantidade
                    break; //Sai do while
                }
                catch
                {
                    Console.WriteLine("Digite um número inteiro válido."); //Exibe erro
                }
            }

            while (true) //While com true pois o break está nas condições
            {
                try //Tenta capturar dado válido até o usuário inserir corretamente
                {
                    Console.Write("Preço unitário (use vírgula para casas decimais): "); //Requisita o preço
                    double entradaPreco = Convert.ToDouble(Console.ReadLine()); 
                    preco = entradaPreco; //Armazena o preço
                    break; //Sai do while
                }
                catch
                {
                    Console.WriteLine("Digite um número válido para o preço."); //Exibe erro
                }
            }

            try
            {
                using (StreamWriter sw = File.AppendText(caminhoArquivo)) //Escreve o produto no txt
                {
                    sw.WriteLine($"{nome},{quantidade},{preco.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}");
                    //Tive que utilizar o método nativo System.Globalization.CultureInfo.InvariantCulture para trocar a vírgula por ponto
                    //Foi necessário pois futuramente é feito um split com vírgula, e a virgula do double atrapalharia o split
                }
                Console.WriteLine("Produto salvo com sucesso!"); //Exibe que o produto foi salvo
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar produto: " + ex.Message); //Exibe erro ao tentar salvar o produto
            }
        }

        static void ListarProdutos() //Cria método para listar os produtos no txt
        {
            if (!File.Exists(caminhoArquivo)) //Verifica se o txt existe através do path 
            {
                Console.WriteLine("Nenhum produto cadastrado."); //Exibe que não tem produto
                return;
            }

            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo); //Armazena todas as linhas num array linhas

                if (linhas.Length == 0) //Verifica se não tem linhas escritas
                {
                    Console.WriteLine("Nenhum produto cadastrado."); //Exibe que não tem produto cadastrado
                    return;
                }

                Console.WriteLine("\n--- Produtos Cadastrados ---");

                foreach (string linha in linhas) //Executa o seguinte bloco de codigo para cada linha no array linhas
                {
                    string[] partes = linha.Split(','); //Utiliza o split na linha para capturar nome quantidade e preço e armazenar num array

                    if (partes.Length != 3) //Se ouver mais de 3 partes no split, dá erro no cadastro 
                    {
                        Console.WriteLine("Erro ao ler uma linha: formato inesperado."); //Exibe erro
                        continue;
                    }

                    try
                    {
                        //Atribui cada parte na sua respectiva variável
                        string nome = partes[0];
                        int quantidade = int.Parse(partes[1]);
                        double preco = double.Parse(partes[2], CultureInfo.InvariantCulture); 
                        //Mantém ponto ao invés de vírgula para não quebrar o código

                        Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: R$ {preco:F2}");
                        //Lista o produto
                    }
                    catch
                    {
                        Console.WriteLine("Erro ao converter os dados de um produto."); //Captura erro de dados no produto
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message); //Captura erro lendo o arquivo
            }
        }

        while (executando) //Menu inserido no while
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine(); //Captura opção digitada

            switch (opcao) //Switch case com as opções, atribuindo cada uma a um número
            {
                case "1":
                    if (contador >=5) //Verifica se chegou no limite de produtos
                    {
                        Console.WriteLine("Limite de produtos atingido!"); //Exibe que chegou no limite
                    }
                    else
                    {
                        InserirProduto(); //Insere o produto 
                        contador++; //Soma 1 no contador de produtos
                    }
                    break;

                case "2":
                    ListarProdutos(); //Lista produtos
                    break;

                case "3":
                    executando = false; //Altera variável condicional do menu
                    Console.WriteLine("Encerrando o programa..."); //Encerra o programa
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente."); //Exibe erro na digitação do menu
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
                        try
                        {
                            Console.Write("Quantidade em estoque: ");
                            int entradaQuantidade = Convert.ToInt32(Console.ReadLine());
                            novoProduto.Quantidade = entradaQuantidade;
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Digite um número inteiro válido para a quantidade.");
                        }
                    }

                    
                    while (true)
                    {
                        try
                        {
                            Console.Write("Preço unitário (use vírgula para casas decimais): ");
                            double entradaPreco = Convert.ToDouble(Console.ReadLine());
                            novoProduto.Preco = entradaPreco;
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