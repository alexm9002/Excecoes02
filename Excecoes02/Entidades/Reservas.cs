using System;
namespace Excecoes.Entidades {
    internal class Reservas {
        public int NumeroQuarto { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public Reservas(int numeroQuarto, DateTime entrada, DateTime saida) {
            this.NumeroQuarto = numeroQuarto;
            this.Entrada = entrada;
            this.Saida = saida;
        }
        public int Duracao() {
            // TimeSpan é usado para calcular duração de um período
            TimeSpan duracao = Saida.Subtract(Entrada);

            // Para transformar em dias usa-se a função "Total.Days"
            // transformando os dados em inteiro, pois o retorno do
            // "TotalDays" é feito em formato "Double".
            return (int)duracao.TotalDays;
        }
        public String AtualizarData(DateTime entrada, DateTime saida) {
            // Como a função vai retornar uma mensagem, ela passa a ser
            // do tipo "String" ao invés de "void"
            DateTime hoje = DateTime.Now;
            if (entrada < hoje || saida < hoje) {
                return "Erro na reserva! A data lançada para reserva precisa ser futura";
            //Não usa o "else", o return desconsidera o restante
            }
            if (saida <= entrada) {
                return "Erro na reserva! Data de Check-out não pode ser anterior a Data de Check-in ";
            }
            this.Entrada = entrada;
            this.Saida = saida;
            return null; // retorna indicando que não houve nenhum erro no objeto 
        }

        public override string ToString() {
            return "Quarto: "
            + NumeroQuarto
            + ", Check-in: "
            + Entrada.ToString("dd/MM/yyyy")
            + ", Check-out: "
            + Saida.ToString("dd/MM/yyyy")
            + ", "
            + Duracao() //Colocar a função e não a variável.
            + " Noites.";
        }
    }
}