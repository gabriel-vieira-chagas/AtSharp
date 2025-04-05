using System;
using System.Globalization;
using System.IO;

class Program
{
    const string caminhoArquivo = @"D:\\INFNET\estoque.txt"; //Cria o caminho para o txt

    static void Main(string[] args)
    {
        bool executando = true; //Inicializa a variável de execução do menu
        int contador = 0; //Inicializa variável para contar quantos produtos foram inseridos

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
 O código começa atribuindo o path de arquivo a uma variável constante, pois esse caminho não será alterado ao longo do código.
Em seguida, são inicializadas as variáveis de execução do menu e contador para quantidade de produtos inseridos.
É criado o método inserir produto, que inicializa nome, quantidade e preço do produto, em seguida requisitando os mesmos.
Quantidade de estoque e preço são requisitados com while e possuem tratamento de erro caso o tipo de dado inserido pelo usuário não seja o dado exigido,
e pede até que ele insira o tipo correto. É inserido então no arquivo o produto, com seus dados arranjados como requisitado.
Foi utilizado o método nativo “System.Globalization.CultureInfo.InvariantCulture” para transformar a vírgula em ponto.
Esse método não era de meu conhecimento, e fui atrás dele na internet para saber como fazia essa alteração. 
Ele foi necessário pois, salvando o double com virgula o meu split sempre dava mais de 3 posições, assim gerando erro no fluxo do código.
O segundo método é o de listar produtos, que inicialmente armazena todas as linhas num array e verifica se há produtos
cadastrados para prosseguir o processo. Caso tenha, ele separa por vírgula a string da linha, que vai separar na posição 0,1 e 2,
respectivamente, nome, quantidade e preço. A variável de preço utiliza o método nativo para transformar ponto em vírgula,
para não quebrar o fluxo do código. Se houver erro, ele exibe no terminal.
É criado então um menu while condicionado pela variável criada no início do código.
Ele exibe as opções com um número, sendo cada número atribuído a um case no switch.
A opção de inserir produto traz consigo um if simples que verifica se o contador de inserção de produtos já chegou no seu limite.
Se tiver chegado, ele exibe a mensagem de que o limitide de cadastro de produtos foi alcançado.
A opção 3 encerra o menu while através da alteração de sua condicional. Caso seja digitado algo além das opções, ele exibe o erro.
 */