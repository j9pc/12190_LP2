// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe ReservasDataReadWritter que implementa a gravação dos dados das reservas criadas para um ficheiro json."
// ***********************************************************************
using BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL
{
    public class ReservasDataReadWritter
    {

        static string filePath = @"C:\Users\JPC\Desktop\reservas_data.json";

        public static bool SaveReservaToFile(Reserva reserva)
        {
            try
            {
                List<Reserva> reservas = new List<Reserva>();

                if (!System.IO.File.Exists(filePath))
                {
                    var myJsonFile = System.IO.File.Create(filePath);
                    myJsonFile.Close();
                }

                var reservasJSON = System.IO.File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(reservasJSON))
                {
                    reservas.Add(reserva);
                }
                else
                {
                    reservas = JsonConvert.DeserializeObject<List<Reserva>>(reservasJSON);
                    reservas.Add(reserva);
                }

                var convertToJson = JsonConvert.SerializeObject(reservas, Formatting.Indented);

                System.IO.File.WriteAllText(filePath, convertToJson);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<Reserva> GetReservas()
        {
            try
            {
                List<Reserva> reservas = new List<Reserva>();

                if (!System.IO.File.Exists(filePath))
                {
                    // returns empty list
                    return reservas;
                }

                var reservasJSON = System.IO.File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(reservasJSON))
                {
                    return reservas;
                }

                reservas = JsonConvert.DeserializeObject<List<Reserva>>(reservasJSON);

                return reservas;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
