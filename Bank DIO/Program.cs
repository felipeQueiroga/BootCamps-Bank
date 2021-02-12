using System;
using System.Collections.Generic;
using Bank_DIO.Classes;
using Bank_DIO.Classes.Enums;

namespace Bank_DIO
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = "";
            while (opcaoUsuario != "X")
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            }
        }
        private static void Depositar()
        {
            Console.Clear();
            ListarContas();
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {
            Console.Clear();
            ListarContas();
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Clear();
            ListarContas();
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta de destino: ");
            int indiceContadestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o Valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListaContas[indiceContaOrigem].Transferir(valorTransferencia, ListaContas[indiceContadestino]);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Fisica ou 2 para conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o saldo inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
            ListaContas.Add(novaConta);

            Console.WriteLine("Conta cadastrada:");
            Console.WriteLine(novaConta.ToString());
        }
        private static void ListarContas()
        {
            if (ListaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
            }
            else
            {
                for (int i = 0; i < ListaContas.Count; i++)
                {
                    Conta c = ListaContas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(c.ToString());
                }
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}