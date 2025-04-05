﻿

class Program
{
    const string caminhoArquivo = @"D:\\INFNET\contatos.txt"; //Cria o caminho para o txt

    static void Main()
    {
        bool executando = true; //Inicializa a variável de execução do menu

        static void AdicionarContato() //Cria método para adcionar 
    {
        Console.Write("\nNome: ");
        string nome = Console.ReadLine(); //Requisita nome

        Console.Write("Telefone no formato(DDD) 9NNNN-NNNN: ");
        string telefone = Console.ReadLine(); //Requisita telefone no formato ddd e números separados por traço

            Console.Write("Email: "); //Requisita email
            string email = Console.ReadLine();

        try //Utiliza try para evitar quebra no fluxo caso cadastre
        {
            using (StreamWriter sw = File.AppendText(caminhoArquivo)) //Escreve no arquivo
            {
                sw.WriteLine($"{nome},{telefone},{email}"); //Escreve como requisitado
            }

            Console.WriteLine("Contato cadastrado com sucesso!"); //Exibe que foi cadastrado com sucesso
        }
        catch (Exception ex) //Captura possíveis erros
        {
            Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
        }
    }

    static void ListarContatos() //Cria método de listar contatos
    {
        if (!File.Exists(caminhoArquivo)) //Verifica se o txt existe através do path 
            {
            Console.WriteLine("Nenhum contato cadastrado."); //Exibe que não tem contato
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo  ); //Armazena todas as linhas num array linhas

            if (linhas.Length == 0) // Verifica se não tem linhas escritas
            {
                Console.WriteLine("Nenhum contato cadastrado."); //Exibe que não tem contato
                return;
            }

            Console.WriteLine("\nContatos cadastrados:");
            foreach (string linha in linhas) //Executa o seguinte bloco de codigo para cada linha no array linhas
            {
                string[] partes = linha.Split(','); //Utiliza o split na linha para capturar nome quantidade e preço e armazenar num array

                    if (partes.Length != 3) //Se ouver mais de 3 partes no split, dá erro no cadastro 
                    {
                        Console.WriteLine("Erro ao ler uma linha: formato inesperado."); //Exibe erro
                        continue;
                    } 
                    else {
                        //Atribui cada parte na sua respectiva variável
                        string nome = partes[0];
                        string telefone = partes[1];
                        string email = partes[2];

                        Console.WriteLine($"Nome: {nome} | Telefone: {telefone} | Email: {email}"); //Lista o contato
                    }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler contatos: {ex.Message}"); //Captura erro ao ler os contatos
        }
    }

        while (executando) //Menu inserido no while
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine(); //Captura opção digitada

            switch (opcao)
            {
                case "1":
                    AdicionarContato(); //Insere o telefone
                    break;
                case "2":
                    ListarContatos(); //Lista os contatos
                    break;
                case "3":
                    executando = false; //Altera variável condicional do menu
                    Console.WriteLine("Encerrando o programa..."); //Encerra o programa
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente."); //Exibe erro na digitação do menu
                    break;
            }

        } 
    }
}