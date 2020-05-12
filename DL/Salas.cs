// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : " Classe Salas que comunica com o BL, esta classe consiste em criar duas salas distintas
//	cada uma delas com 200 camas, métodos estáticos "
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Excepcoes;


namespace DL
{
    /// <summary>
    /// Classe que define o objeto Salas.
    /// </summary>
    public class Salas
    {
        static List<Sala> gestorSalas;

        static Salas()
        {
            gestorSalas = new List<Sala>();
        }

        /// <summary>
        /// Retorna o número de Salas
        /// </summary>
        /// <returns>Numero de Salas.</returns>
        public static int NumeroDeSalas()
        {
            try
            {
                return gestorSalas.Count;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Método para inserir a Sala
        /// </summary>
        /// <returns> A Sala.</returns>
        /// <param name="idSala">Id da Sala.</param>

        public static bool InserirSala(EnumSalas idSala)
        {
            try
            {
                Sala sala = RetornaSala(idSala);

                if (sala == null)
                {
                    sala = new Sala(idSala);
                    gestorSalas.Add(sala);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Método para retornar a Sala
        /// </summary>
        /// <returns><c>true</c>, a Sala, <c>false</c> se não.</returns>
        /// <param name="idSala">Id da Sala.</param>
        private static Sala RetornaSala(EnumSalas idSala)
        {
            if (gestorSalas.Count == 0)
            {
                return null;
            }

            foreach (Sala sala in gestorSalas)
            {
                if (sala.IdSala.Equals(idSala))
                {
                    return sala;
                }
            }

            return null;

        }

        /// <summary>
        /// Método para inserir a Sala com o seu max de camas
        /// </summary>
        /// <returns> A sala.</returns>
        /// <param name="idSala">Id da Sala.</param>
        /// <param name="maxCamas">max de Camas.</param>
        public static bool InserirSalaMax(EnumSalas idSala, int maxCamas)
        {
            try
            {
                Sala sala = RetornaSala(idSala);

                if (sala == null)
                {
                    sala = new Sala(idSala, maxCamas);
                    gestorSalas.Add(sala);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        /// <summary>
        /// Método para remover a Sala
        /// </summary>
        /// <returns> A sala.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static bool RemoverSala(EnumSalas idSala)
        {
            try
            {
                Sala sala = RetornaSala(idSala);

                if (sala != null)
                {
                    gestorSalas.Remove(sala);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        /// <summary>
        /// Retorna o total de camas na sala indicada.
        /// Sala [1] e Sala [2]
        /// </summary>
        /// <returns>As camas na sala.</returns>
        /// <param name="idSala">Id da sala.</param>
        public static int TotalCamasNaSala(EnumSalas idSala)
        {
            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.MaxSala;
            }

            return 0;
        }

        /// <summary>
        /// Retorna o total de camas disponiveis.
        /// </summary>
        /// <returns>As disponiveis.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static int CamasDisponiveis(EnumSalas idSala)
        {

            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.CamasLivres();
            }

            return 0;
        }

        /// <summary>
        /// Retorna o total de reservas disponiveis.
        /// </summary>
        /// <returns>As disponiveis.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static int ReservasDisponiveis(EnumSalas idSala)
        {

            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.ReservasDisponiveis();
            }

            return 0;
        }

        /// <summary>
        /// Retorna o número de reservas ativas de uma Pessoa
        /// </summary>
        /// <returns>AS ativas.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static int ReservasAtivas(EnumSalas idSala)
        {
            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.ReservasAtivas();
            }

            return 0;
        }

        /// <summary>
        /// Retorna o número máximo de camas disponiveis para reserva no dia atual
        /// </summary>
        /// <returns>As reservas.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static int MaxReservas(EnumSalas idSala)
        {

            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.MaxReservas();
            }

            return 0;
        }

        /// <summary>
        /// Regras para associar uma pessoa. Se associar retorna true, 
        /// caso contrário retorna false e atira a excepção relacionada com a falha.
        /// O Método recebe uma Pessoa, e o número da Sala a colocar.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns><c>true</c>, se foi associada, <c>false</c> se não.</returns>
        /// <param name="pessoa">Pessoa.</param>
        /// <param name="idSala">Id da Doca.</param>
        public static bool TentaAssociar(Pessoa pessoa, EnumSalas idSala)
        {
            try
            {

                Sala sala = RetornaSala(idSala);

                if (sala != null)
                {
                    return sala.Associar(pessoa);
                }

            }
            catch (ExceptionPessoaColocada)
            {
                throw new ExceptionPessoaColocada();
            }
            catch (ExceptionSalaCheia)
            {
                throw new ExceptionSalaCheia();
            }
            catch (ExceptionDataExpirada)
            {
                throw new ExceptionDataExpirada();
            }
            catch (ExceptionSemReserva)
            {
                throw new ExceptionSemReserva();
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Regra para reservar camas. Se bem sucedida retorna True. 
        /// caso contrário retorna false e atira a excepção relacionada com a falha.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns><c>true</c>, se cama reservada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static bool ReservarCama(Reserva reserva, EnumSalas idSala)
        {
            try
            {
                // validámos a possibilidade de reservar uma cama
                Sala sala = RetornaSala(idSala);

                if (sala != null)
                {
                    return sala.ReservarCama(reserva);
                }

            }
            catch (ExceptionPessoaColocada)
            {
                throw new ExceptionPessoaColocada();
            }
            catch (ExceptionProblemaNaReserva)
            {
                throw new ExceptionProblemaNaReserva();
            }
            catch (ExceptionReservaExistente)
            {
                throw new ExceptionReservaExistente();
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return false;

        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para a data "Dia do Ano" e sala indicada.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns>Na data.</returns>
        /// <param name="data">Data.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static List<Reserva> CamasOcupadasNaData(DateTime data, EnumSalas idSala)
        {
            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.CamasOcupadasNaData(data);
            }

            return null;
        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para o numero de CC indicado.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns>Na data.</returns>
        /// <param name="idSala">Id da Sala.</param>
        /// <param name="numeroCC">numero de CC.</param>
        public static List<Reserva> NumerosDeCCReservas(EnumSalas idSala, int numeroCC)
        {

            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.NumerosDeCCReservas(numeroCC);
            }

            return null;
        }

        /// <summary>
        /// Método de cancelamento de reservas. Retorna TRUE caso seja bem sucedido, 
        /// caso contrário retorna FALSE e respectiva exceção.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns><c>true</c> se conseguiu cancelar a reserva na nSala, <c>false</c> se não. </returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="data">Data.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static bool CancelarReserva(int numeroCC, DateTime data, EnumSalas idSala)
        {
            try
            {
                Sala sala = RetornaSala(idSala);

                if (sala != null)
                {
                    return sala.CancelarReserva(numeroCC, data);
                }

            }
            catch (ExceptionSemReserva)
            {
                throw new ExceptionSemReserva();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Retorna uma lista com as pessoas já associadas a camas na presente Data.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns>As colocadas.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static List<Pessoa> PessoasColocadas(EnumSalas idSala)
        {
            Sala sala = RetornaSala(idSala);

            if (sala != null)
            {
                return sala.PessoasColocadas();
            }

            return null;
        }

        /// <summary>
        /// Regra para remover pessoas das camas, caso seja bem sucedido retorna TRUE. 
        /// caso contrário retorna FALSE e respectiva exceção.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns><c>true</c>, se a pessoa foi removida, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static bool RemoverPessoa(int numeroCC, EnumSalas idSala)
        {
            try
            {
                Sala sala = RetornaSala(idSala);

                if (sala != null)
                {
                    return sala.RemoverPessoa(numeroCC);
                }

            }
            catch (ExceptionProblemaNaReserva)
            {
                throw new ExceptionProblemaNaReserva();
            }
            catch (ExceptionSemPessoa)
            {
                throw new ExceptionSemPessoa();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }
    }
}
