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