using System.Text;

namespace Disval.Entidades
{
    public class CCV
    {
        public int ID { get; set; }
        public int PuntoDeVenta { get; set; }
        public int Comprobante { get; set; }
        public DateTime FechaDeEmision { get; set; }



        public static CCV DeLineaACCV(string linea)
        {
            try
            {
                int transaccion = int.Parse(linea.Substring(0, 12));
                int puntoDeVenta = int.Parse(linea.Substring(16, 4));
                int comprobante = int.Parse(linea.Substring(20, 8));
                DateTime fecha = ObtenerFecha(linea);

                CCV cCV = new CCV();
                cCV.ID = transaccion;
                cCV.PuntoDeVenta = puntoDeVenta;
                cCV.Comprobante = comprobante;
                cCV.FechaDeEmision = fecha;
                return cCV;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DateTime ObtenerFecha(string linea)
        {
            int anio = int.Parse(linea.Substring(28,4));
            int mes = int.Parse(linea.Substring(32,2));
            int dia = int.Parse(linea.Substring(34,2));

            return new DateTime(anio,mes,dia);

        }
    }
}
