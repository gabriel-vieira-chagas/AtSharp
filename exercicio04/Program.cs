
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite sua data de nascimento no formato (dd/MM/yyyy): "); //Requisita a data num formato específico
        string data = Console.ReadLine(); //Captura o dado inserido pelo usuário

        try //Código inserido dentro do try para capturar erro no formato do DateTime
        {
            DateTime nascimento = DateTime.Parse(data); // Transforma entrada do usuário em data. Aqui é onde pode dar erro e encerrar a aplicação.
            DateTime hoje = DateTime.Today; //Define a data do dia para utilizar nas operações.

            int ano = hoje.Year; //Obtém o ano atual
            int mes = nascimento.Month; //Obtém o mes da data de nascimento
            int dia = nascimento.Day; // Obtém o dia da data de nascimento

            DateTime aniversario = new DateTime(ano, mes, dia); //Após as capturas acima, define a data de aniversario ainda podendo alterar
            int idade = ano - nascimento.Year; //Define quantos anos o usuário vai fazer, ainda podendo alterar

            if (aniversario < hoje) //Verifica se o aniversário já ocorreu
            {
                aniversario = new DateTime(ano + 1, mes, dia); //Caso já tenha passado, soma 1 no ano para definir data correta
                idade += 1; //Caso já tenha passado, soma 1 na idade para definir corretamente
            }

            double dias = (aniversario - hoje).TotalDays; //Finalmente faz a operação para saber quanto falta, capturando a resposta em dias


            if (dias == 0)
            {
                Console.WriteLine($"Parabéns, hoje é seu aniversário de {idade} anos!"); //Exibe ao usuário que seu aniversário é hoje
            }
            else if (dias == 1)
            {
                Console.WriteLine($"Falta apenas {dias} dia para o seu aniversário de {idade} anos."); //Exibe ao usuário que falta apenas um dia
            }
            else
            {
                Console.WriteLine($"Faltam {dias} dias para seu aniversário de {idade} anos."); //Exibe ao usuário quantos dias faltam
            }
        }
        catch (Exception ex)
        { //Captura erro no formato do DateTime
            Console.WriteLine("\nDigite uma data válida.");
            Console.WriteLine("Erro: " + ex.Message); //Exibe erro caso usuário não digite uma data válida
        }
    }
}

/*
O código se inicia capturando uma data inserida pelo usuário,
que se não estiver no formato correto ao entrar no try catch, exibe o erro e encerra a aplicação automaticamente.
Após seguir com a data correta, as informações do dia atual são definidas para poder fazer os eventuais cálculos.
A partir disso, com informações de ano atual, mês do nascimento e dia do nascimento é formado o aniversário.
Também é definida a idade do usuário. É feita a verificação para caso o usuário já tenha feito aniversário esse ano,
assim adicionando mais um ano na data para poder saber quantos dias falta para o próximo.
Também é adicionado mais um ano na idade, nesse caso.
O programa então calcula a diferença para saber quantos dias faltam para este próximo aniversário
e exibe uma mensagem de parabéns caso seja hoje,
uma mensagem tratada para caso falte apenas um dia e uma mensagem geral para o resto dos casos.
Na mensagem também é exibido quantos anos o usuário fará neste próximo aniversário.
O catch exibe a mensagem de erro e qual erro foi cometido pelo usuário.
 */