
using exercicio6; //Importa namespace para manipular classe aluno

public class Program
{
    public static void Main(string[] args)
    {
        //Cria objeto gabriel com os dados deste aluno específico
        Aluno gabriel = new Aluno("Gabriel Vieira Chagas", 1234, "Engenharia de Software", 9.8);
        //Cria objeto giovani com os dados deste aluno específico
        Aluno giovani = new Aluno("Giovani Marlon", 5678, "Artes Cênicas", 5.4);

        gabriel.ExibirDados(); //Método que exibe dados desse aluno específico
        gabriel.VerificarAprovacao(); //Método que verifica aprovação desse aluno específico

        giovani.ExibirDados(); //Método que exibe dados desse aluno específico
        giovani.VerificarAprovacao(); //Método que verifica aprovação desse aluno específico
    }
}

/*
 Em Aluno.cs, o código começa atribuindo o namespace do exercício para ser chamado no Program.
Em seguida, é declarada a classe Aluno, armazenando os dados requisitados com get e set,
permitindo acessar e modificar os valores quando necessário. Get permite ler a propriedade e set permite alterá-la.
É criado então o construtor para poder atribuir os parâmetros às propriedades.
No exemplo do objeto “gabriel” o construtor é chamado e atribui o parâmetro “Gabriel Vieira Chagas” à propriedade “Nome”.
São criados na sequência ambos os métodos ExibirDados() e VerificarAprovacao(), que fazem respectivamente,
exibir os dados preenchidos do aluno e verifica através de um if simples se a média é maior do que sete,
para retornar aprovação ou reprovação do aluno.
No Program.cs, o namespace que contém a classe é chamado inicialmente,
e no Main() são criados os objetos de dois alunos com seus respectivos dados.
Por fim, são chamados ambos os métodos para cada aluno, exibindo as informações de dados e aprovação.
 */