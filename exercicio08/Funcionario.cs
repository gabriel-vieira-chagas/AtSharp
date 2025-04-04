using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio8 //Define o namespace para chamada no Program
{
    internal class Funcionario //Cria classe funcionário
    {
        public string Nome { get; set; } //Armazena nome do funcionário

        public string Cargo { get; set; } //Armazena cargo do funcionário

        public double SalarioBase { get; set; } //Armazena salário base do funcionário (com get e set pois será manipulado futuramente)

        public Funcionario(string nome, string cargo, double salarioBase) //Cria construtor da classe que recebe e atribui os dados
        {
            Nome = nome;
            Cargo = cargo;
            SalarioBase = salarioBase;
            //Atribuição de parâmetro à propriedade
        }

        public virtual void ExibirSalario() //Cria método para exibir o salário juntamente com nome e cargo
        {
            Console.WriteLine($"{Nome} ({Cargo}) - Salário: R$ {SalarioBase:F2}\n"); //Exibe as informações

        }

    }
}