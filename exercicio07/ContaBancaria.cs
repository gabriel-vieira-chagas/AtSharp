using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercicio7 //Define o namespace para chamada no Program
{
    public class ContaBancaria //Declara classe de conta bancaria
    {
        public string Titular { get; set; } //Armazena nome do titular
        private decimal Saldo; //Armazena saldo do titular (sem get set por ser saldo)

        public ContaBancaria(string titular, decimal saldo) //Cria construtor da classe que recebe e atribui os dados
        {
            Titular = titular;
            Saldo = saldo;
            //Atribuição de parâmetro à propriedade
        }

        public void Depositar(decimal deposito) //Cria método para depositar com o tipo requisitado
        {
            if (deposito > 0) //Faz verificação pra ver se o deposito é positivo
            {
                Saldo += deposito; //Atualiza saldo
                Console.WriteLine($"Depósito de R$ {deposito:F2} realizado com sucesso!\n"); //Exibe depósito
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo!\n"); //Exibe mensagem de erro
            }
        }

        public void Sacar(decimal saque) //Cria método para sacar com tipo requisitado
        {
            if (Saldo >= saque) //Verifica se o valor de saque é menor que o saldo
            {
                Saldo -= saque; //Desconta no saldo
                Console.WriteLine($"Saque de R$ {saque:F2} realizado com sucesso!\n"); //Exibe valor do saque
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar o saque de R$ {saque:F2}!\n"); // Exibe mensagem de erro 
            }
        }

        public void ExibirSaldo() //Cria método para exibir saldo como requisitado
        {
            Console.WriteLine($"Saldo atual: R$ {Saldo:F2}\n"); //Exibe saldo
        }

        public void ExibirTitular() //Cria método para exibir nome do titular
        {
            Console.WriteLine($"Titular: {Titular}\n"); //Exibe nome do titular
        }
    }
}
