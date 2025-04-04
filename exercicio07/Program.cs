using exercicio7; //Importa namespace para manipular classe ContaBancaria

public class Program
{
    public static void Main(string[] args)
    {
        ContaBancaria conta1 = new ContaBancaria("Gabriel Vieira Chagas", 20); //Cria objeto conta1 com os dados da conta

        conta1.ExibirTitular(); //Utiliza o método exibir titular para exibir o nome do titular
        conta1.ExibirSaldo(); //Utiliza o método exibir saldo para exibir saldo inicial
        conta1.Depositar(-50); //Utiliza o método depositar para tentar depositar negativo e receber mensagem de erro
        conta1.Depositar(248.86m); //Faz depósito válido
        conta1.ExibirSaldo(); //Exibe o saldo
        conta1.Sacar(352.70m); //Utiliza o método sacar para tentar sacar um valor inválido e receber mensagem de erro
        conta1.ExibirSaldo(); //Exibe o saldo
        conta1.Sacar(154.62m); //Faz saque válido
        conta1.ExibirSaldo(); //Exibe o saldo
    }
}

/*
Em ContaBancaria.cs, o código começa atribuindo o namespace do exercício para ser chamado no Program.
Em seguida, é declarada a classe ContaBancaria, armazenando os dados requisitados com get e set no nome do titular e sem get e set no saldo.
O saldo, por ser um valor que não pode ser alterado manualmente, não pode ter get e set, pois isso traz a capacidade de manipular esse dado.
É criado então o construtor com a atribuição de parâmetro à propriedade já explicada previamente, o modo é o mesmo.
São criados então os métodos de Depositar, Sacar, ExibirSaldo e ExibirTitular. Depositar requisita uma quantia para depósito,
adicionando o valor no saldo caso seja positivo, do contrário, ele exibe uma mensagem de erro. O saque tem um processo parecido,
já que Sacar requisita a quantia para saque, removendo da conta caso tenha a quantidade desejada.
Caso não tenha, exibe mensagem de erro. ExibirSaldo e ExibirTitular somente exibem, respectivamente,
o valor do saldo da conta e o nome do titular da conta. O método de exibir titular não foi requisitado,
mas foi criado para deixar o Main mais padronizado e compacto. Em Program.cs o namespace que contém a classe é importado.
O objeto conta1 é criado com os dados necessários, e em seguida vem uma série de métodos para demonstrar sua funcionalidade.
Nome e saldo do titular da conta1 são exibidos, é feita uma tentativa de deposito negativo para exibir
a mensagem de erro e é feito então um depósito correto, exibindo logo depois o saldo. Com saldo alterado,
agora é feita uma tentativa de saque inválido, além do que há na conta, para exibir a mensagem de erro.
Após exibição dessa mensagem o programa mostra que o saldo não foi alterado e saca uma quantia possível.
Por fim é exibido novamente o saldo para demonstrar a diferença na conta.
 */