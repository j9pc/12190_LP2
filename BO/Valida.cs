// ***********************************************************************
// Assembly         : BO
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe Valida, tem o objetivo de validar se os números do CC são colocados corretamente"
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BO
{
    public static class Valida
    {
        /// <summary>
        /// Método interno para a validação dos números do CC.
        /// </summary>
        /// <returns><c>true</c>, se o numero de CC foi validado, <c>false</c> se não.</returns>
        /// <param name="registo">numero.</param>
        public static bool NumeroCC(string numeroCC)
        {

            if (numeroCC != null)
            {
                var valida = new Regex(@"^[0-9]{8}$");
                if (valida.IsMatch(numeroCC))
                {
                    return true;
                }
                else
                {
                    // caso contrário a excepção é lançada
                    throw new Exception();
                }
            }
            return false;
        }
    }
}
