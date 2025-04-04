

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite a data de hoje no formato (dd/MM/yyyy): "); // Requisita a data num formato específico
        string data = Console.ReadLine(); // Captura o dado inserido pelo usuário
        DateTime atual = DateTime.Now;

        try
        {
            DateTime hoje = DateTime.ParseExact(data, "dd/MM/yyyy", null);
            // Transforma entrada do usuário em data. Aqui é onde pode dar erro e encerrar a aplicação.
            DateTime dataFormatura = new DateTime(2024, 12, 15); // Define a data de formatura 
            string exibirDataFormatura = dataFormatura.ToString("dd/MM/yyyy"); //Cria variável para exibir de comparação
            string exibirDataAtual = atual.ToString("dd/MM/yyyy"); //Cria variável para exibir de comparação

            int anosRestantes = 0; // Inicializa a variável de anos restantes
            int mesesRestantes = 0; // Inicializa a variável de meses restantes
            int diasRestantes = 0; // Inicializa a variável de dias restantes

            while (hoje.AddYears(1) <= dataFormatura) // Adiciona um ano na data atual até ultrapassar a data da formatura
            {
                hoje = hoje.AddYears(1); // Adiciona um ano
                anosRestantes++; // Incrementa o contador de anos restantes
            }

            while (hoje.AddMonths(1) <= dataFormatura) // Adiciona um mês na data atual até ultrapassar a data da formatura
            {
                hoje = hoje.AddMonths(1); // Adiciona um mês à data atual
                mesesRestantes++; // Incrementa o contador de meses restantes
            }

            diasRestantes = (dataFormatura - hoje).Days; // Calcula dias restantes subtraindo data atual da data da formatura

            Console.WriteLine("Data da formatura: " + exibirDataFormatura + "\n"); //Exibe variável
            if (hoje > atual)
            { //Verifica se a data inserida é maior que a data real
                Console.WriteLine("Data atual real: " + exibirDataAtual + "\n"); //Exibe variável de comparação
                Console.Write("Erro: A data informada não pode ser no futuro!\n"); //Exibe mensagem de erro
            }
            else if (hoje > dataFormatura) //Verifica se ja passou da formatura
            {
                Console.Write("Parabéns! Você já deveria estar formado!\n"); //Exibe mensagem requisitada
            }
            else if (hoje == dataFormatura) //Verifica se é no dia digitado
            {
                Console.Write("Parabéns! Sua formatura é hoje!\n"); //Exibe mensagem especial
            }
            else if (anosRestantes == 0 && mesesRestantes < 6 && diasRestantes > 0)
            { //Verifica se entá dentro dos 6 meses
                Console.WriteLine($"Faltam {mesesRestantes} meses e {diasRestantes} dias para a sua formatura!");
                Console.Write("A reta final chegou! Prepare-se para a formatura!\n"); //Exibe mensagem requisitada
            }
            else if (anosRestantes == 0 && mesesRestantes >= 6) //Verifica se o ano é zero para nao exibir 0 anos
            {
                Console.WriteLine($"Faltam {mesesRestantes} meses e {diasRestantes} dias para a sua formatura!"); //Exibe mensagem requisitada
            }
            else
            {
                Console.WriteLine($"Faltam {anosRestantes} anos {mesesRestantes} meses e {diasRestantes} dias para a sua formatura!\n");
                // Exibe contagem regressiva para a formatura
            }

        }
        catch (Exception ex) // Captura erro no formato do DateTime
        {
            Console.WriteLine("\nDigite uma data válida."); // Exibe uma mensagem pedindo uma data válida
            Console.WriteLine("Erro: " + ex.Message + "\n"); // Exibe erro caso usuário não digite uma data válida
        }
    }
}

/*
 O código começa requisitando a data para executar a aplicação e capturando o dado inserido pelo usuário,
que caso não tenha sido inserido no formato válido encerra a aplicação e avisa ao usuário que ele inseriu
de maneira errada assim que entrar no try. 
A data atual real, do dia que a aplicação for utilizada é captada para futuros processos no código.
A data de formatura é definida manualmente como requisitado na questão, e são criadas duas variáveis para 
exibir a comparação com ações futuras do código, sendo ambas datas formatadas para string. 
A variável “hoje”, aquela inserida pelo usuário, entra num processo de “atualização” 
para ser comparada com a data de formatura já inserida manualmente. Ela vai adicionando anos até chegar no ano da formatura. 
Caso isso não seja possível, ele mantém o ano inserido e vai para o próximo passo. A etapa se repete com os meses,
também não sendo alterados caso não seja possível. Por fim, os dias restantes são calculados de maneira mais simples,
capturando a diferença da data atualizada com a data da formatura. Todos os processos utilizam métodos nativos
de manipulação de data para que automaticamente sejam contabilizados os meses com dias corretos (28, 29, 30 ou 31 dias) e anos bissextos.
É exibida então a data da formatura a título de comparação com o que vem seguinte.
É feito um if para verificar caso a data inserida pelo usuário seja uma data maior que a data atual,
gerada no começo no código, exibindo a mensagem de erro requisitada. A verificação seguinte é se caso a data de formatura já passou,
que está propositalmente após a primeira verificação, pois caso fosse a primeira ela não corrigiria o usuário por inserir uma data futura.
Caso a data inserida seja a mesma da formatura, é exibida uma mensagem única especial de parabenização.
A verificação seguinte é se está dentro dos 6 meses para exibir a mensagem requisitada.
Na sequência entra uma verificação para não exibir “0 anos” na saída, e por fim a saída geral que abrange anos, meses e dias.
No fim do código encontra-se o bloco de catch, que exibe o erro e correção para o usuário que digitar uma data inválida.
 */