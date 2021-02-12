using System;
using Bank_DIO.Classes.Enums;

namespace Bank_DIO.Classes
{
    class Conta
    {
        public TipoConta TipoConta { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }
        public double Credito { get; private set; }

        public Conta()
        {
        }

        public Conta(TipoConta TipoConta, string Nome, double Saldo, double Credito)
        {
            this.TipoConta = TipoConta;
            this.Nome = Nome;
            Depositar(Saldo);
            this.Credito = Credito;
        }

        public void Depositar(double quantia)
        {
            Saldo += quantia;
        }
        public bool Sacar(double quantia)
        {
            if (Saldo >= quantia)
            {
                Saldo -= quantia;
                return true;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque!");
                return false;
            }
            MostrarSaldo();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }

        }
        public override String ToString()
        {
            return "Nome: " + Nome +
              "| Saldo: " + Saldo +
              "| Credito: " + Credito;
        }

        public void MostrarSaldo()
        {
            Console.WriteLine("O Saldo atual da conta de: " + Nome + " é " + Saldo);
        }
    }
}