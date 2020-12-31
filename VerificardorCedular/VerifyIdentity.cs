using System;
using System.Collections.Generic;
using System.Linq;

namespace VerificardorCedular
{
    public class VerifyIdentity
    {
        public static bool IdentificationCard(string NumeroCedula)
        {
            List<int> Numero = new List<int>();

            if (NumeroCedula != "000-0000000-0" | NumeroCedula != "00000000000")
            {
                NumeroCedula = NumeroCedula.Replace("-", "");

                for (int i = 0; i < 11; i++)
                {
                    try
                    {
                        string Sub = NumeroCedula.Substring(i, 1);

                        Numero.Add(Convert.ToInt32(Sub));
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }
            else
            {
                return false;
            }

            return IdentificationCardId(Numero);
        }


        private static bool IdentificationCardId(List<int> Numero)
        {
            List<int> ResultadoMult = new List<int>();
            int ResultadoSuma = 0;

            try
            {
                #region "Multiplicando"

                int Multiplo = 1;
                int Cambio(int x)
                {
                    return x > 1 ? 1 : 2;
                }

                int contador = 0;
                foreach (int N in Numero)
                {
                    contador++;

                    if (contador < 11)
                    {
                        ResultadoMult.Add(N * Multiplo);

                        Multiplo = Cambio(Multiplo);
                    }
                }

                #endregion


                #region "Sumando"

                foreach (int valor in ResultadoMult)
                {
                    if (valor >= 10)
                    {
                        string y = valor.ToString();

                        ResultadoSuma += Convert.ToInt32(y.Substring(0, 1)) + Convert.ToInt32(y.Substring(1, 1));
                        Console.Write((Convert.ToInt32(y.Substring(0, 1)) + Convert.ToInt32(y.Substring(1, 1))).ToString() + "-");
                        Console.WriteLine("");
                    }

                };

                foreach (int valor in ResultadoMult)
                {
                    if (valor < 10)
                    {
                        ResultadoSuma += valor;
                    }
                };

                #endregion


                #region "Verificando"
                int ResulDecena = 0;
                string ResulString = "";


                ResulString = ResultadoSuma.ToString();

                ResulDecena = (10 - Convert.ToInt32(ResulString.Substring(1, 1)));

                if (ResulDecena != 10)
                {
                    ResulDecena = ResultadoSuma + ResulDecena;
                }
                else
                {
                    ResulDecena = ResultadoSuma;
                }

                ResultadoSuma = (ResulDecena - ResultadoSuma);

                Numero.Reverse();

                #endregion

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


            bool Resultado(int x)
            {
                return x == Numero.First() ? true : false;
            }


            return Resultado(ResultadoSuma);
        }


    }
}
