namespace Disval.Helpers
{
    public class Validar
    {
        public static int ValidarDeStringAInt(string linea)
        {
            bool verifica = false;
            int retorno = -1;
            verifica = int.TryParse(linea.Trim(), out retorno);
            if (verifica)
                return retorno;

            throw new Exception("No se pudo convertir el string a int");
        }


        public static double ValidarDeStringADouble(string linea)
        {
            string lineaDos = linea.Trim();
            bool verifica = false;
            double retorno = -1;
            verifica = double.TryParse(lineaDos, out retorno);
            if (verifica)
                return retorno;

            throw new Exception("No se pudo convertir el string a double");

        }

        public static DateTime ValidarDeStringADatetimeAMD(string linea, char separador)
        {

            String[] substring = linea.Split(separador);

            DateTime fechaRetorno = new DateTime(ValidarDeStringAInt(substring[2]), ValidarDeStringAInt(substring[1]), ValidarDeStringAInt(substring[0]));

            return fechaRetorno;

        }

        public static DateTime ValidarDeStringADateTimeAAAAMMDD(string linea)
        {
            string year = linea.Substring(0, 4);
            string month = linea.Substring(4, 2);
            string day = linea.Substring(6, 2);

            return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

        }

        public static double EliminaPuntosYRetornaDouble(string asda)
        {
            string retorno = string.Empty;

            foreach (char item in asda)
            {
                if (item != '.' && item != ',' && item != '$' && item != ' ')
                {
                    retorno = retorno + item;
                }
            }

            Double retornoDouble;
            try
            {
                double.TryParse(retorno, out retornoDouble);
                return retornoDouble;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string ParseaArchivo(string lineaArchivo, int primeraPosicion, int length)
        {
            string retorno = string.Empty;

            try
            {
                retorno = lineaArchivo.Substring(primeraPosicion, length);
            }
            catch
            {
                Console.WriteLine("No se pudo parsear");
            }

            return retorno;

        }

        public static string EliminaMultiplesEspacios(string texto)
        {
            string retorno = "";
            string text = texto.Trim();
            bool espacioRepetido = false;
            foreach (char item in text)
            {
                if (item != ' ')
                {
                    retorno = retorno + item;
                    espacioRepetido = false;
                }



                if (item == ' ' && espacioRepetido == false)
                {
                    retorno = retorno + item;
                    espacioRepetido = true;
                }
                if (item == ' ' && espacioRepetido == true)
                {

                }


            }
            return retorno;
        }

    }
}
