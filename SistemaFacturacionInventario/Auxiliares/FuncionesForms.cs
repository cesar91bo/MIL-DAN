using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionInventario.Auxiliares
{
    public static class FuncionesForms
    {
        public static bool NroEneteroInt32(string valor)
        {
            Int32 i;
            if (Int32.TryParse(valor, out i) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // SI EL NRO ES DECIMAL
        public static bool NroDecimal(object valor)
        {
            decimal i;
            if (decimal.TryParse(valor.ToString(), out i) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
