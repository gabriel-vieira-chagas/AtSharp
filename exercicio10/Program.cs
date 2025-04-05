

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

/*
 O código começa declarando e inicializando uma série de variáveis que serão utilizadas no decorrer do código.
Primeiro é declarada a variável random para instanciar a classe nativa Random do System.
Em seguida é gerado e armazenado um número aleatório no intervalo de 1 a 51, sendo 1 incluso e e 51 excluso.
Dessa forma, o intervalo de números é, na prática, de 1 a 50. O palpite da adivinhação é inicializado como inteiro,
de mesmo modo que a variável de chances. As condições de acerto e chance são inicializadas como false, para serem utilizadas no while futuro.
O tratamento de entrada também é inicializado como false e será importante para aceitar ou não a entrada do usuário.
O código exibe o número para poder facilitar a depuração e a exemplificação.
É exibida uma mensagem de título e criado um while onde está inserido a maior parte do código.
Este while é interrompido caso o usuário tenha chegado na quinta chance e errado nela também,
assim não permitindo ter mais chances como requisitado, ou no caso do usuário ter acertado o número.
É criado um while então para verificar se a entrada do usuário é um número inteiro no intervalo de 1 a 50.
Qualquer coisa além disso mantém a condição de entrada como false, e segue requisitando uma entrada válida sem gastar as chances do usuário.
Caso ele tenha colocado um número válido, é atribuído true para o tratamento, e ele passa para o próximo if do código,
que apenas exibe se o palpite foi menor ou maior do que o número secreto. Em seguida é verificado se as chances acabaram,
ou se o número foi acertado com dois ifs simples. No fim do while a chance recebe um acréscimo e o tratamento é atribuído novamente para false,
para que o processo possa ser reiniciado, já que sem ele ali somente o primeiro número é gravado, travando o while.
Por fim, se a condição de acerto for verdadeira, é exibida a mensagem de acerto.
Do contrário, é exibida a mensagem dizendo que o usuário não acertou e revelando o número.
 */