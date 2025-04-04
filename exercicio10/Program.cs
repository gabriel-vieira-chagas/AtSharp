

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); //Declara variável random para instanciar a classe nativa Random do System 
        int numeroSecreto = random.Next(1, 51); //Gera um numero aleatorio no intervalo de 1 a 51, sendo o numero 51 exclusivo
        int palpite = 0; // Inicializa variável de palpite
        int chances = 1; //Inicializa variável de quantidade de chances
        bool condicaoAcerto = false; //Inicializa variável de condição de acerto
        bool condicaoChances = false; //Inicializa variável de condição de chance
        bool tratamentoEntrada = false; //Inicializa tratamento de entrada

        Console.WriteLine($"-= Num: {numeroSecreto} =- "); //Exibe o número secreto para facilitar depuração

        Console.WriteLine("Você tem 5 chances para advinhar o número secreto de 1 a 50!\n"); //Mensagem de exibição inicial
        while (condicaoChances == false && condicaoAcerto == false) //Cria while para que o loop pare caso acerte ou acabe as chances
        {
            while (tratamentoEntrada == false){
                Console.Write($"Chance n° {chances}: "); //Exibe numero de chances e requisita tentativa
                try //Verifica se o que foi digitado é um número inteiro válido
                {
                    palpite = Convert.ToInt32(Console.ReadLine()); //Recebe tentativa
                    if (palpite > 50 || palpite < 0) //Verifica se o palpite é maior 50 ou menor que 0
                    {
                        Console.WriteLine("Por favor, digite um número inteiro de 1 a 50.\n"); //Exibe erro
                    }
                    else
                    {
                        tratamentoEntrada = true; //Permite que a entrada passe
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Por favor, digite um número inteiro de 1 a 50.\n"); //Exibe erro
                }
            }

            if (palpite < numeroSecreto) //Caso palpite seja menor exibe uma mensagem
            {
                Console.WriteLine("O número secreto é maior.\n");

            }
            else if (palpite > numeroSecreto) //Caso palpite seja maior exibe uma mensagem
            {
                Console.WriteLine("O número secreto é menor.\n");

            }

            if (chances >= 5) //Altera a condicao para encerrar o loop caso tenham acabado as chances
            {
                condicaoChances = true;
            }

            if (palpite == numeroSecreto) //Altera a condicao para encerrar o loop caso tenha acertado o número
            {
                condicaoAcerto = true;
            }
            chances++; //Aumenta o contador de chances
            tratamentoEntrada = false; //Reinicia o processo de tratamento de entrada
        }
        if (condicaoAcerto) //Caso tenha acertado exibe mensagem de acerto
        {
            Console.WriteLine("Parabéns! Você acertou o número secreto!");
        }
        else
        {
            Console.WriteLine($"Não foi dessa vez, você errou! O número secreto era {numeroSecreto}."); //Exibe mensagem de erro e o número
        }
    }
}