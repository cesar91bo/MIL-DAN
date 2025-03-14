using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Logger
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public void RegistrarError(string origen, string metodo, Exception ex)
        {
            try
            {
                // Llamada al procedimiento almacenado utilizando el contexto de Entity Framework
                db.Database.ExecuteSqlCommand(
                    "EXEC SP_InsertarLogError @Origen, @Metodo, @Mensaje, @StackTrace",
                    new SqlParameter("@Origen", origen),
                    new SqlParameter("@Metodo", metodo),
                    new SqlParameter("@Mensaje", ex.Message),
                    new SqlParameter("@StackTrace", ex.ToString())
                );
            }
            catch (Exception logEx)
            {
                // Si hay un error al guardar el log, lo mostramos en la consola o lo guardamos en un archivo local
                Console.WriteLine("Error al guardar log en la base de datos: " + logEx.Message);
            }
        }
    }
}
