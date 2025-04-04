using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio8 //Define o namespace para chamada no Program
{
    internal class Gerente : Funcionario //Cria a subclasse gerente
    {
        public Gerente(string nome, double salarioBase) : base(nome, "Gerente", salarioBase) { } //Cria o construtor da subclasse
        public override void ExibirSalario() //Cria método que sobrescreve o método de funcionário quando chamado por gerente
        {
            double salarioBonus = SalarioBase * 1.2; //Cálculo de bonus no salário
            Console.WriteLine($"{Nome} ({Cargo}) - Salário: R$ {salarioBonus:F2}\n"); //Exibe bonus no salário, nome e cargo

        }
    }
}
