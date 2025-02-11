﻿using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AuxiliaresNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public bool EditarUMedida(UnidadesMedida umed)
        {
            try
            {
                EditarUmedida(umed);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EditarUmedida(UnidadesMedida umed)
        {
            var unidad = db.UnidadesMedida.SingleOrDefault(c => c.IdUnidadMedida == umed.IdUnidadMedida);
            unidad.Descripcion = umed.Descripcion;
            db.SaveChanges();
        }

        public bool EditarRubro(Rubros rubro)
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NuevaUMedida(UnidadesMedida umed)
        {
            try
            {
                AgregarUmedida(umed);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public void AgregarUmedida(UnidadesMedida um)
        {
            db.UnidadesMedida.Add(um);
            db.SaveChanges(); 
        }

        #region Consultas
        public List<Rubros> ObtenerRubros()
        {
            return db.Rubros.OrderBy(c => c.IdRubro).ToList();
        }

        public List<UnidadesMedida> ObtenerUMedida()
        {
            return db.UnidadesMedida.OrderBy(c=>c.IdUnidadMedida).ToList();
        }

        public UnidadesMedida ObtenerUMedidaPorId(int idUMed)
        {
            return db.UnidadesMedida.SingleOrDefault(c => c.IdUnidadMedida == idUMed);
        }

        public bool BorrarUMedida(int idUnidadMedida)
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                if (productoNegocio.ObtenerTodo().Any(c => c.IdUnidadMedida == idUnidadMedida))
                {
                    return false;
                }
                else
                {
                    var unidad = db.UnidadesMedida.SingleOrDefault(u => u.IdUnidadMedida == idUnidadMedida);
                    if (unidad != null)
                    {
                        db.UnidadesMedida.Remove(unidad);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
