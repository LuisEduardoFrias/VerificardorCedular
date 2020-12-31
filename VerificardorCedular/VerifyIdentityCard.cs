
namespace VerificardorCedular
{
    using System;

    public class VerifyIdentityCard
    {
        /// <summary>
        /// An integer array of length 11
        /// </summary>
        /// <param name="IdNumber"></param>
        /// <returns></returns>
        public static bool IdentificationCard(int[] IdNumber)
        {
            return IdNumber.Length == 11 ? Verifying(
                ResultSum(
                    Multiplying(IdNumber)), IdNumber) : false;
        }

        private static int[] Multiplying(int[] IdNumber)
        {
            int[] MultiplierResult = new int[10];

            int Multiplo = 1;

            for(int i = 0; i < IdNumber.Length-1; i++)
            {
                MultiplierResult[i] = IdNumber[i] * Multiplo;

                Multiplo = Multiplo > 1 ? 1 : 2;
            }

            return MultiplierResult;
        }

        private static int ResultSum(int[] MultiplierResult)
        {
            int ResultadoSuma = 0;

            foreach (int valor in MultiplierResult)
                if (valor >= 10)
                    ResultadoSuma += Convert.ToInt32(valor.ToString().Substring(0, 1)) + 
                                     Convert.ToInt32(valor.ToString().Substring(1, 1));

            foreach (int valor in MultiplierResult)
                if (valor < 10)
                    ResultadoSuma += valor;

            return ResultadoSuma;
        }

        private static bool Verifying(int ResultSum, int[] IdNumber)
        {
            int ResulDecena;

            ResulDecena = (10 - int.Parse(ResultSum.ToString().Substring(1, 1)));

            if (ResulDecena != 10)
                return (ResultSum + ResulDecena) - ResultSum == IdNumber[10];
            else
                return ResultSum == IdNumber[10];

        }

    }
}
