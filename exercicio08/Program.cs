using exercicio8; //Importa namespace para manipular classe ContaBancaria

public class Program
{
    public static void Main(string[] args)
    {
        Funcionario funcionario = new Funcionario("Gabriel Vieira Chagas", "Desenvolvedor", 1500); //Cria objeto funcionario com os dados necessários
        funcionario.ExibirSalario(); //Exibe as informações

        Gerente gerente = new Gerente("Jorge Geraldo", 1500); //Cria objeto gerente com os dados necessários
        gerente.ExibirSalario(); //Exibe as informações
    }
}

/*
 A classe Funcionario.cs é criada, e armazena nome, cargo e salário base.
É criado seu construtor, atribuindo parâmetro à propriedade e também é criado o método de exibir o salário, que exibe nome,
cargo e salário do funcionário. Esse método é criado com virtual, para poder ser feito o override na subclasse Gerente em ações futuras.
Já em Gerente.cs é criada uma subclasse da classe funcionário.
Seu construtor é criado com uma base, para automaticamente inserir o cargo gerente quando um gerente for adicionado.
É feito então um override do método ExibirSalario, para exibir o salário do gerente que possui bônus de 20%.
No Program.cs é criado um funcionário e um gerente com as informações necessárias, ambas sendo exibidas com o método exibir salário.
Ambos recebem o mesmo salário base, mas o do gerente é exibido já com o bônus aplicado.
 */