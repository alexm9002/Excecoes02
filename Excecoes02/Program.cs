using System;
using System.Collections.Generic;
using System.Globalization;
using Excecoes.Entidades;


namespace Excecoes {
    class Program {
        static void Main(string[] args) {
            Console.Write("Número do Quarto: ");
            int numeroQuarto = int.Parse(Console.ReadLine());
            Console.Write("Data do Check-in (dd/MM/yyyy): ");
            DateTime entrada = DateTime.Parse(Console.ReadLine());
            Console.Write("Data do Check-out (dd/MM/yyyy):");
            DateTime saida = DateTime.Parse(Console.ReadLine());

            if (saida <= entrada) {
                Console.WriteLine("Erro na reserva! Data de Check-out não pode ser anterior a Data de Check-in ");
            }
            else {
                Reservas reservas = new Reservas(numeroQuarto, entrada, saida);
                Console.WriteLine("Reserva --> " + reservas);
                Console.WriteLine();
                Console.WriteLine("Entre com os dados para atualizar a reserva!");
                Console.Write("Data do Check-in (dd/MM/yyyy): ");
                entrada = DateTime.Parse(Console.ReadLine());
                Console.Write("Data do Check-out (dd/MM/yyyy):");
                saida = DateTime.Parse(Console.ReadLine());

                string erro = reservas.AtualizarData(entrada, saida);
                if (erro != null) {
                    Console.WriteLine("Erro na reserva" + erro);
                }
                else {
                    Console.WriteLine("Reservas: " + reservas);
                }
            }
        }
    }
}