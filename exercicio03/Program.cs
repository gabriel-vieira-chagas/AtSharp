

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-- Calculadora de Operações Matemáticas --"); //Exibe este 'título' apenas uma vez
        bool saida = true; //Inicializa variável de saída do while 
        double resultado = 0; //Inicializa variável de resultado
        try //Utiliza o try para exibir erro de dado e encerrar a aplicação
        {
            do //Loop do while para executar as operações até que o usuário saia 
            {
                Console.Write("Digite o primeiro número da operação: ");
                double num1 = Convert.ToDouble(Console.ReadLine()); //Coleta o primeiro número
                Console.Write("Digite o segundo número da operação: ");
                double num2 = Convert.ToDouble(Console.ReadLine()); //Coleta o segundo número

                Console.WriteLine("\nDigite apenas o número da operação que você deseja fazer");
                Console.Write("1. Soma\n2. Subtração\n3. Multiplicação\n4. Divisão\n5. Sair da aplicação\nOperação:");
                string escolhaOperacao = Console.ReadLine();//Coleta a operação

                if (escolhaOperacao == "1") //Executa operação de soma
                {
                    resultado = num1 + num2; //Altera a variável resultado para receber a soma
                    Console.WriteLine($"\nA operação escolhida foi: 1. Soma\n{num1} + {num2} = {resultado}"); //Exibe resultado
                    Console.WriteLine(""); //Pula uma linha
                }
                else if (escolhaOperacao == "2") //Executa operação de subtração
                {
                    resultado = num1 - num2; //Altera a variável resultado para receber a subtração
                    Console.WriteLine($"\nA operação escolhida foi: 2. Subtração\n{num1} - {num2} = {resultado}");//Exibe resultado
                    Console.WriteLine(""); //Pula uma linha
                }
                else if (escolhaOperacao == "3") //Executa operação de multiplicação
                {
                    resultado = num1 * num2; //Altera a variável resultado para receber a multiplicação
                    Console.WriteLine($"\nA operação escolhida foi: 3. Multiplicação\n{num1} * {num2} = {resultado}");//Exibe resultado
                    Console.WriteLine(""); //Pula uma linha
                }
                else if (escolhaOperacao == "4") //Executa operação de soma
                {
                    if (num2 == 0) //Verifica se há divisão por zero
                    {
                        Console.WriteLine("\nNão é possível dividir por zero."); //Exibe erro ao tentar dividir por zero
                        Console.WriteLine(""); //Pula uma linha
                    }
                    else
                    {
                        resultado = num1 / num2; //Altera a variável resultado para receber a divisão
                        Console.WriteLine($"\nA operação escolhida foi: 4. Divisão\n{num1} / {num2} = {resultado}");//Exibe resultado
                        Console.WriteLine("");//Pula uma linha
                    }
                }
                else if (escolhaOperacao == "5") //Encerra a aplicação
                {
                    Console.WriteLine("\nVocê encerrou a aplicação."); //Exibe saída
                    Console.WriteLine(""); //Pula uma linha
                    saida = false;
                }
                else //Caso não seja uma das escolhas válidas, executa o seguinte código
                {
                    Console.WriteLine("\nDigite uma operação válida."); //Exibe erro de operação inválida
                    Console.WriteLine(""); //Pula uma linha
                }
            } while (saida);
        }
        catch (Exception ex) //Captura erro para exibir
        {
            Console.WriteLine("\nDigite um número válido.");
            Console.WriteLine("Erro: " + ex.Message); //Exibe erro caso usuário não digite um número
        }
    }
}

/*
 O código começa inicializando ambas as variáveis de saída resultado. 
A de saída serve para sair do loop do while, enquanto a de resultado servirá para exibir o resultado da operação que o usuário escolher.
O processo ocorre dentro de um try catch, para que caso o usuário digite um número inválido, a aplicação para.
Dentro do try catch há o loop do while, que se inicia pedindo ao usuário para digitar os dois números para fazer a operação.
Depois, é exibido um “menu” com as opções de operação e saída. Caso o usuário digite qualquer coisa que não seja uma das opções,
o código informa seu erro e pede novamente para que digite os números e sua operação. Ao digitar uma das operações possíveis,
é feita a conta e exibido o resultado. A exibição é dinâmica, sempre exibindo o os números, operação e resultado.
Se o usuário escolher a operação de divisão, é criado um outro if para verificar se o segundo número digitado, no caso o divisor, é zero.
Se o divisor for zero, é exibida a mensagem de que não se pode dividir por zero e o programa pede novamente os dados.
Caso ele digite a opção de sair da aplicação, ela se encerra.
O try catch exibe o erro ao usuário ao digitar um número inválido.
 */