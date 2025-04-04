using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio6 //Define o namespace para chamada no Program
{
    internal class Aluno // Declara classe Aluno
    {
        private string Nome { get; set; } //Armazena nome do aluno
        private int Matricula { get; set; } //Armazena matrícula do aluno
        private string Curso { get; set; } //Armazena curso do aluno
        private double Media { get; set; } //Armazena média do aluno

        public Aluno(string nome, int matricula, string curso, double media) //Cria construtor da classe que recebe e atribui os dados
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
            Media = media;
            //Atribuição de parâmetro à propriedade
        }

        public void ExibirDados() //Método de exibição requisitado
        {
            Console.WriteLine("Exibição de dados do aluno:"); //Exibição dos dados
            Console.WriteLine($"Nome: {Nome}"); //Exibe nome
            Console.WriteLine($"Matrícula: {Matricula}"); //Exibe matrícula
            Console.WriteLine($"Curso: {Curso}"); //Exibe curso
            Console.WriteLine($"Média das Notas: {Media}\n"); //Exibe nota
        }

        public void VerificarAprovacao() //Método de verificar aprovação requisitado
        {
            if (Media >= 7) //Verifica se a média é maior ou igual a sete
            {
                Console.WriteLine($"Aprovação de {Nome}: Aprovado\n"); //Exibe resposta de aprovado
            }
            else
            {
                Console.WriteLine($"Aprovação de {Nome}: Reprovado\n"); //Exibe resposta de reprovado
            }
        }
    }
}
