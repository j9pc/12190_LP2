// ***********************************************************************
// Assembly         : Main-TP-12190
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Main do Projeto"
// ***********************************************************************
using BL;
using BO;
using System;
using System.Collections.Generic;

namespace Main_TP_12190
{
    class Program
    {
        static void Main(string[] args)
        {

            #region MENU

            if (!CriarSalas() && GestorSalas.NumeroDeSalas() != 2)
            {
                Console.WriteLine("Ocorreu um erro ao criar as Salas");
                System.Environment.Exit(1);
            }

            int numeroCC;
            bool menu = false, colocar, valida = false;
            int opcao;
            Pessoa pessoa;
            Reserva reserva;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[+] ");
                Console.ResetColor();
                Console.Write("Camas Disponiveis\\Total");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t\t\t[+] ");
                Console.ResetColor();
                Console.WriteLine("Numero de Reservas\\Total");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[1] ");
                Console.ResetColor();
                Console.Write("{0} - {1}\\{2}", EnumSalas.Sala1.ToString(), GestorSalas.CamasDisponiveis(EnumSalas.Sala1), GestorSalas.TotalCamas(EnumSalas.Sala1));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t\t\t\t[1] ");
                Console.ResetColor();
                Console.Write("{0} - {1}\\{2}\n", EnumSalas.Sala1.ToString(), GestorSalas.NumeroReservas(EnumSalas.Sala1), GestorSalas.MaxReservas(EnumSalas.Sala1));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[2] ");
                Console.ResetColor();
                Console.Write("{0} - {1}\\{2}", EnumSalas.Sala2.ToString(), GestorSalas.CamasDisponiveis(EnumSalas.Sala2), GestorSalas.TotalCamas(EnumSalas.Sala2));
                Console.Write("\t\t\t[2] ");
                Console.ResetColor();
                Console.WriteLine("{0} - {1}\\{2}", EnumSalas.Sala2.ToString(), GestorSalas.NumeroReservas(EnumSalas.Sala2), GestorSalas.MaxReservas(EnumSalas.Sala2));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                Console.Write("\n[0]  Sair da Aplicação\n");
                Console.Write("[1]  Nova pessoa\n");
                Console.Write("[2]  Reservar Cama\n");
                Console.Write("[3]  Cancelar Reserva\n");
                Console.Write("[4]  Retirar pessoa\n");
                Console.Write("[5]  Consultar Reservas para Determinada Data\n");
                Console.Write("[6]  Consultar Reservas para Determinada NumeroCC\n");
                Console.Write("[7]  Consultar pessoas colocadas\n");
                Console.Write(">>> ");
                menu = int.TryParse(Console.ReadLine(), out opcao);
                switch (opcao)
                {
                    case 1:
                        CriarPessoa(out pessoa);
                        Console.WriteLine("\nOs dados inseridos são os seguintes:\n");
                        MostrarPessoa(pessoa);
                        try
                        {
                            colocar = AssociarPessoa(pessoa, GetSala());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            colocar = false;
                        }

                        if (colocar)
                        {
                            Console.WriteLine("\nA pessoa foi colocada com sucesso");
                        }
                        Console.WriteLine("Prima qualquer tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        bool aux;
                        CriarPessoa(out pessoa);
                        reserva = CriarReserva(pessoa);

                        do
                        {
                            try
                            {
                                aux = RegistarReserva(reserva, GetSala());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                aux = false;
                            }

                            if (aux)
                            {
                                Console.WriteLine("Cama reservada com sucesso\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                            }

                            if (!aux)
                            {
                                Console.Write("Não foi possivel reservar a cama\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                                Console.Clear();
                                aux = true;
                            }
                        } while (!aux);
                        break;

                    case 3:

                        DateTime data;
                        do
                        {
                            Console.Write("Insira o número de CC da Reserva\n>>> ");
                            aux = int.TryParse(Console.ReadLine(), out numeroCC);
                            try
                            {
                                valida = Valida.NumeroCC(numeroCC);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        } while (!valida);

                        if (valida)
                        {
                            bool cancela = false;
                            data = DatasReserva(true);
                            try
                            {
                                cancela = CancelarReserva(numeroCC, data, GetSala());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                            }

                            if (cancela)
                            {
                                Console.WriteLine("Reserva cancelada com sucesso");
                                Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                            }

                        }
                        break;

                    case 4:
                        do
                        {
                            Console.Write("Insira o número de CC da Pessoa\n>>> ");
                            aux = int.TryParse(Console.ReadLine(), out numeroCC);
                            try
                            {
                                valida = Valida.NumeroCC(numeroCC);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        } while (!valida);

                        if (valida)
                        {
                            bool saiu = false;
                            try
                            {
                                saiu = GestorSalas.RemoverPessoa(numeroCC, GetSala());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                            }
                            if (saiu)
                            {
                                Console.WriteLine("Pessoa retirada com sucesso\n");
                                Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case 5:
                        MostrarReservas(GestorSalas.CamasOcupadasNaData(DatasReserva(false), GetSala()));
                        break;

                    case 6:
                        do
                        {
                            Console.Write("Insira o número do CC da pessoa\n>>> ");
                            aux = int.TryParse(Console.ReadLine(), out numeroCC);
                            try
                            {
                                valida = Valida.NumeroCC(numeroCC);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        } while (!valida);
                        MostrarReservas(GestorSalas.NumerosDeCCReservas(numeroCC, GetSala()));
                        break;

                    case 7:
                        Console.Write("\n");
                        MostrarColocadas(GestorSalas.PessoasColocadas(GetSala()));
                        Console.Write("\nPrima Qualquer Tecla para Voltar ao Menu >>> ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (!menu || opcao != 0);


            Console.WriteLine("End of Demo\n Prima QlQr Tecla para sair");

            Console.ReadKey();
        }

        #endregion

        /// <summary>
        /// Método auxiliar de criação das salas.
        /// </summary>
        /// <returns><c>true</c>, salas criadas, <c>false</c> se não.</returns>
        static bool CriarSalas()
        {
            try
            {
                return (GestorSalas.InserirSala(EnumSalas.Sala1) && GestorSalas.InserirSala(EnumSalas.Sala2));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        /// <summary>
        /// Método auxiliar de criação de uma pessoa.
        /// </summary>
        /// <returns><c>true</c>, Pessoa criada, <c>false</c> se não.</returns>
        /// <param name="pessoa">Pessoa.</param>
        static bool CriarPessoa(out Pessoa pessoa)
        {
            try
            {
                pessoa = new Pessoa();

                int idade;
                int numeroCC;
                bool evalNumeroCC, aux;

                Console.Write("Insira o nome da pessoa\n\t>>> ");
                pessoa.Nome = Console.ReadLine().ToUpper();


                do
                {
                    Console.Write("Insira a idade da Pessoa\n(Ex: 57)\t>>> ");
                    aux = int.TryParse(Console.ReadLine(), out idade);
                    if (!aux || idade < 0)
                    {
                        Console.WriteLine("Insira uma idade valida (Ex: 57)");
                        aux = false;
                    }
                } while (!aux);

                pessoa.Idade = idade;

                do
                {
                    Console.Write("Insira a matricula do barco do barco\n\tFormato: 00-00-00\n\t>>>");
                    evalNumeroCC = int.TryParse(Console.ReadLine(), out numeroCC);

                    try
                    {
                        evalNumeroCC = Valida.NumeroCC(numeroCC);
                        pessoa.NumeroCC = numeroCC;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        evalNumeroCC = false;
                    }
                } while (!evalNumeroCC);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna a lista de pessoas colocadas
        /// </summary>
        /// <param name="pessoa">Pessoa.</param>
        static void MostrarPessoa(Pessoa pessoa)
        {
            Console.WriteLine("Nome da Pessoa -> {0}", pessoa.Nome);
            Console.WriteLine("Idade da Pessoa -> {0}", pessoa.Idade);
            Console.WriteLine("Número de CC da pessoa -> {0}", pessoa.NumeroCC);
            Console.WriteLine("____________________________________________________________");
        }

        /// <summary>
        /// Método auxiliar para associar as pessoas ás camas.
        /// </summary>
        /// <returns><c>true</c>, Pessoa colocada, <c>false</c> se não.</returns>
        /// <param name="pessoa">Pessoa.</param>
        /// <param name="nSalas">N sala.</param>
        private static bool AssociarPessoa(Pessoa pessoa, EnumSalas nSalas)
        {
            bool aux;

            try
            {
                aux = GestorSalas.TentaAssociarPessoa(pessoa, nSalas);
            }
            catch (Exception ex)
            {
                aux = false;
                Console.WriteLine(ex.Message);
            }

            return aux;

        }

        /// <summary>
        /// Método auxiliar que define a Sala.
        /// </summary>
        static EnumSalas GetSala()
        {
            int index = 0;
            bool menu = false;
            int opcao;
            do
            {
                Console.WriteLine("Selecione uma das Salas");
                Console.WriteLine("[ -1 ] para sair");
                foreach (EnumSalas sala in Enum.GetValues(typeof(EnumSalas)))
                {
                    Console.WriteLine("[ " + index++ + " ]" + sala.ToString());
                }
                index = 0;
                menu = int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        return (EnumSalas)1;
                    case 2:
                        return (EnumSalas)2;
                    default:
                        Console.Clear();
                        break;
                }
            } while (!menu || opcao != -1);

            return 0;
        }

        /// <summary>
        /// Método auxiliar de criação de uma reserva.
        /// </summary>
        /// <returns><c>true</c>, Reserva ativada, <c>false</c> se não.</returns>
        /// <param name="barco">Barco.</param>
        private static Reserva CriarReserva(Pessoa pessoa)
        {
            var reserva = new Reserva();
            bool aux;

            reserva.PessoaReserva = pessoa;

            do
            {
                try
                {
                    reserva.DataEntrada = DatasReserva(false);
                    aux = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    aux = false;
                }
            } while (!aux);

            //reserva.DataSaida = reserva.DataEntrada.AddHours(InputHoras(reserva.DataEntrada));

            return reserva;
        }

        /// <summary>
        /// Método auxiliar de registo de uma reserva.
        /// </summary>
        /// <returns><c>true</c>, reserva registada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        /// <param name="nSalas">N sala.</param>
        private static bool RegistarReserva(Reserva reserva, EnumSalas nSalas)
        {
            bool aux = false;
            try
            {
                aux = GestorSalas.ReservarCama(reserva, nSalas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return aux;
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

        /// <summary>
        /// Retorna a lista das pessoas já colocadas.
        /// </summary>
        /// <returns><c>true</c>, se pessoa colocada, <c>false</c> se não.</returns>
        /// <param name="colocadas">Colocadas.</param>
        private static bool MostrarColocadas(List<Pessoa> colocadas)
        {
            if (colocadas == null)
            {
                Console.WriteLine("Não há pessoas colocadas");
                return false;
            }

            for (int i = 0; i < colocadas.Count; i++)
            {
                Console.WriteLine("\nAs pessoas colocadas na Sala são as seguintes: \n\n");
                Console.WriteLine("Número de CC da pessoa -> {0}", colocadas[i].NumeroCC);
                Console.WriteLine("Nome da pessoa -> {0}", colocadas[i].Nome);
                Console.WriteLine("Idade da pessoa -> {0}", colocadas[i].Idade);
                Console.WriteLine("____________________________________________________________");
            }
            return true;
        }

        /// <summary>
        /// Método auxiliar no cancelamento de reservas, pede a data caso seja pedido um cancelamento e returna a mesma
        /// </summary>
        /// <param name="cancela">Cancela.</param>
        private static DateTime DatasReserva(bool cancela)
        {
            bool aux;
            DateTime data;
            string message = "Insira a data pretendida\nEx:\"2021-01-10 10:30\"\t>>> ";

            if (cancela)
            {
                message = "Insira o dia da Reserva\nEx:\"2021-01-10\"\t>>> ";
            }

            do
            {
                Console.Write(message);
                aux = DateTime.TryParse(Console.ReadLine(), out data);
            } while (!aux);

            return data;
        }

        /// <summary>
        /// Método de cancelamento de reservas. Retorna TRUE caso o cancelamento tenha sido bem sucedido.
        /// FALSE caso não o seja, e atira uma excpção.
        /// </summary>
        /// <returns><c>true</c> se reserva cancelada, <c>false</c>se não.</returns>
        private static bool CancelarReserva(int numeroCC, DateTime dia, EnumSalas nSala)
        {
            bool aux;

            try
            {
                aux = GestorSalas.CancelarReserva(numeroCC, dia, nSala);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return aux;
        }
    }
}

