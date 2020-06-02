using System;
using System.Collections.Generic;
using BO;
namespace TestSaveReadToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reserva res = new Reserva();

            //res.DataEntrada = DateTime.Now;
            //res.Colocada = true;
            //res.PessoaReserva.Idade = 32;
            //res.PessoaReserva.NumeroCC = 18293;


            //Reserva resii = new Reserva();

            //resii.DataEntrada = DateTime.Now;
            //resii.Colocada = true;
            //resii.PessoaReserva.Idade = 32;
            //resii.PessoaReserva.NumeroCC = 18293;

            //BL.ReservasBL.SaveReserva(res);

            //BL.ReservasBL.SaveReserva(resii);

            //Console.WriteLine("Hello World!");


            //MostrarReservas(BL.ReservasBL.GetReservas());
            //MostrarReservas(BL.PessoasBL.GetPessoas());
        }

        /// <summary>
        /// Retorna a lista de reservas por data.
        /// </summary>
        /// <param name="ocupadas">Ocupadas.</param>
        private static void MostrarReservas(List<Reserva> ocupadas)
        {
            if (ocupadas == null || ocupadas.Count == 0)
            {
                Console.WriteLine("\nNão há reservas no dia indicado");
                Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            for (int i = 0; i < ocupadas.Count; i++)
            {
                Console.WriteLine("Reserva [{0}] Ocupada", i + 1);
                Console.WriteLine("Reserva [{0}] Número de CC da pessoa -> {1}", i + 1, ocupadas[i].PessoaReserva.NumeroCC);
                Console.WriteLine("Reserva [{0}] Hora de Entrada -> {1}", i + 1, ocupadas[i].DataEntrada);
                Console.WriteLine("Reserva [{0}] Hora de Saida -> {1}", i + 1, ocupadas[i].DataSaida);
                Console.WriteLine("____________________");
            }
            return;
        }
    }
}
