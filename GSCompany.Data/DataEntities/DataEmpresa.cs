using GSCompany.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GSCompany.Models.Empresa;

namespace GSCompany.Data.DataEntities
{
    public class DataEmpresa
    {
        readonly GSCompanyEntities _conection = new GSCompanyEntities();
        private readonly DataRol dataRol = new DataRol();
        public string CrearEmpresa(string IdUser, string Modulo, string NombreEmpresa, int IdTipoDocumento, string IdentificacionEmpresa, string EmailEmpresa, string TelefonoEmpresa, string ContactoEmpresa, string DireccionEmpresa, int IdCiudad)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varModulo = new SqlParameter("@Modulo", SqlDbType.VarChar) { Value = Modulo };
                var varNombreEmpresa = new SqlParameter("@NombreEmpresa", SqlDbType.VarChar) { Value = NombreEmpresa };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacionEmpresa = new SqlParameter("@IdentificacionEmpresa", SqlDbType.VarChar) { Value = IdentificacionEmpresa };
                var varEmailEmpresa = new SqlParameter("@EmailEmpresa", SqlDbType.VarChar) { Value = EmailEmpresa };
                var varTelefonoEmpresa = new SqlParameter("@TelefonoEmpresa", SqlDbType.VarChar) { Value = TelefonoEmpresa };
                var varContactoEmpresa = new SqlParameter("@ContactoEmpresa", SqlDbType.VarChar) { Value = ContactoEmpresa };
                var varDireccionEmpresa = new SqlParameter("@DireccionEmpresa", SqlDbType.VarChar) { Value = DireccionEmpresa };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearEmpresa @IdUser, @Modulo, @NombreEmpresa, @IdTipoDocumento, @IdentificacionEmpresa, @EmailEmpresa, @TelefonoEmpresa, @ContactoEmpresa, @DireccionEmpresa, @IdCiudad, @Resultado OUTPUT", varIdUser, varModulo, varNombreEmpresa, varIdTipoDocumento, varIdentificacionEmpresa, varEmailEmpresa, varTelefonoEmpresa, varContactoEmpresa, varDireccionEmpresa, varIdCiudad, varResultado);

                resultado = Convert.ToString(varResultado.Value);
            }
            catch (Exception ex)
            {
                var Rol = dataRol.BuscarRolUsuario(IdUser);
                if (Rol == "Administrador")
                {
                    resultado = "Error__" + ex.Message;
                }
                else
                {
                    if (ex.Message.Contains("No se puede insertar"))
                    {
                        resultado = "Error__No se puede insertar valores duplicados, la Empresa (" + NombreEmpresa + ") ya Existe";
                    }
                    else
                    {
                        resultado = "Error__En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public List<GridEmpresa> GridEmpresa()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridEmpresa>("SP_GridEmpresa").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GuardarCambiosEmpresa(string IdUser, string Modulo, int IdEmpresa, string NombreEmpresa, int IdTipoDocumento, string IdentificacionEmpresa, string EmailEmpresa, string TelefonoEmpresa, string ContactoEmpresa, string DireccionEmpresa, int IdCiudad, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varModulo = new SqlParameter("@Modulo", SqlDbType.VarChar) { Value = Modulo };
                var varIdEmpresa = new SqlParameter("@IdEmpresa", SqlDbType.Int) { Value = IdEmpresa };
                var varNombreEmpresa = new SqlParameter("@NombreEmpresa", SqlDbType.VarChar) { Value = NombreEmpresa };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacionEmpresa = new SqlParameter("@IdentificacionEmpresa", SqlDbType.VarChar) { Value = IdentificacionEmpresa };
                var varEmailEmpresa = new SqlParameter("@EmailEmpresa", SqlDbType.VarChar) { Value = EmailEmpresa };
                var varTelefonoEmpresa = new SqlParameter("@TelefonoEmpresa", SqlDbType.VarChar) { Value = TelefonoEmpresa };
                var varContactoEmpresa = new SqlParameter("@ContactoEmpresa", SqlDbType.VarChar) { Value = ContactoEmpresa };
                var varDireccionEmpresa = new SqlParameter("@DireccionEmpresa", SqlDbType.VarChar) { Value = DireccionEmpresa };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosEmpresa @IdUser, @Modulo, @IdEmpresa, @NombreEmpresa, @IdTipoDocumento, @IdentificacionEmpresa, @EmailEmpresa, @TelefonoEmpresa, @ContactoEmpresa, @DireccionEmpresa, @IdCiudad, @Activo, @Resultado OUTPUT", varIdEmpresa, varIdUser, varModulo, varNombreEmpresa, varIdTipoDocumento, varIdentificacionEmpresa, varEmailEmpresa, varTelefonoEmpresa, varContactoEmpresa, varDireccionEmpresa, varIdCiudad, varActivo, varResultado);

                resultado = Convert.ToString(varResultado.Value);
            }
            catch (Exception ex)
            {
                var Rol = dataRol.BuscarRolUsuario(IdUser);
                if (Rol == "Administrador")
                {
                    resultado = "Error__" + ex.Message;
                }
                else
                {
                    if (ex.Message.Contains("No se puede insertar"))
                    {
                        resultado = "Error__No se puede insertar valores duplicados, la Empresa (" + NombreEmpresa + ") ya Existe";
                    }
                    else
                    {
                        resultado = "Error__En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public List<ListaEmpresa> ListaEmpresa()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaEmpresa>("SP_ListaEmpresa").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string EliminarEmpresa(string IdUser, string Modulo, int IdEmpresa)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varModulo = new SqlParameter("@Modulo", SqlDbType.VarChar) { Value = Modulo };
                var varIdEmpresa = new SqlParameter("@IdEmpresa", SqlDbType.Int) { Value = IdEmpresa };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarEmpresa @IdUser, @Modulo, @IdEmpresa, @Resultado OUTPUT", varIdUser, varModulo, varIdEmpresa, varResultado);

                resultado = Convert.ToString(varResultado.Value);
            }
            catch (Exception ex)
            {
                var Rol = dataRol.BuscarRolUsuario(IdUser);
                if (Rol == "Administrador")
                {
                    resultado = "Error__" + ex.Message;
                }
                else
                {
                    resultado = "Error__En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                }
            }
            return resultado;
        }
    }
}
