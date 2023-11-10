using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

/// <summary>
/// Descripción breve de DalWebService
/// </summary>
public class DalWebService
{
    Database DB;
    public string asignarTramite(string documento, string serie)
    {
        string resultado = string.Empty;
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("Asignar_Tramite_WebService"))
            {

                DB.AddInParameter(dbCommand, "DocumentoCodigo", DbType.Int32, Convert.ToInt32(documento));
                DB.AddInParameter(dbCommand, "SerieCodigo", DbType.String, serie);
                DB.AddOutParameter(dbCommand, "resultado", DbType.String, 500);                
                DB.ExecuteDataSet(dbCommand);
                resultado = DB.GetParameterValue(dbCommand, "@resultado").ToString();
                return resultado;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal int ValidarDocumento(string documento)
    {
        int result = 0;
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("validarDocumento_WebService"))
            {

                DB.AddInParameter(dbCommand, "documento", DbType.String, Convert.ToInt32(documento));
                result = Convert.ToInt32(DB.ExecuteScalar(dbCommand));
                return result;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal int ValidarSerie(string serie)
    {
        int result = 0;
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("validarSerie_WebService"))
            {

                DB.AddInParameter(dbCommand, "serie", DbType.String, serie);
                result = Convert.ToInt32(DB.ExecuteScalar(dbCommand));
                return result;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void AsociarRespuestaARadicado(int registro, int radicado)
    {
        
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("RadicadoFuente_CreateRadicadoFuente"))
            {

                DB.AddInParameter(dbCommand, "GrupoRegistroCodigo", DbType.String,"2");
                DB.AddInParameter(dbCommand, "RegistroCodigo", DbType.Int32,registro);
                DB.AddInParameter(dbCommand, "GrupoRadicadoCodigoFuente", DbType.String, "1");
                DB.AddInParameter(dbCommand, "RadicadoCodigoFuente", DbType.Int32, radicado);
                DB.ExecuteScalar(dbCommand);                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal string RegistrarTramite(out string Result, string GrupoCodigo, DateTime WFMovimientoFecha, string ProcedenciaCodDestino, 
        string DependenciaCodDestino, string DependenciaCodigo, string NaturalezaCodigo, int RadicadoCodigo, string RegistroDetalle, 
        string RegistroGuia, string RegistroEmpGuia, string AnexoExtRegistro, string LogDigitador, string ExpedienteCodigo, 
        string MedioCodigo, string SerieCodigo, string RegPesoEnvio, string RegValorEnvio, string RegistroTipo, string WFAccionCodigo, 
        DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, string WFMovimientoNotas, 
        string WFMovimientoMultitarea, string UserId)
    {        
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("Registro_CreateRegistro_sage"))
            {
                DB.AddOutParameter(dbCommand, "RegistroCodigo", DbType.Int32, 4);
                DB.AddOutParameter(dbCommand, "error", DbType.String, 200);
                DB.AddInParameter(dbCommand, "GrupoCodigo", DbType.String, GrupoCodigo);
                DB.AddInParameter(dbCommand, "WFMovimientoFecha", DbType.DateTime, WFMovimientoFecha);
                DB.AddInParameter(dbCommand, "ProcedenciaCodDestino", DbType.String, ProcedenciaCodDestino);
                DB.AddInParameter(dbCommand, "DependenciaCodDestino", DbType.String, DependenciaCodDestino);
                DB.AddInParameter(dbCommand, "DependenciaCodigo", DbType.String, DependenciaCodigo);
                DB.AddInParameter(dbCommand, "NaturalezaCodigo", DbType.String, NaturalezaCodigo);
                DB.AddInParameter(dbCommand, "RadicadoCodigo", DbType.Int32, RadicadoCodigo);
                DB.AddInParameter(dbCommand, "RegistroDetalle", DbType.String, RegistroDetalle);
                DB.AddInParameter(dbCommand, "RegistroGuia", DbType.String, RegistroGuia);
                DB.AddInParameter(dbCommand, "RegistroEmpGuia", DbType.String, RegistroEmpGuia);
                DB.AddInParameter(dbCommand, "AnexoExtRegistro", DbType.String, AnexoExtRegistro);
                DB.AddInParameter(dbCommand, "LogDigitador", DbType.String, LogDigitador);
                DB.AddInParameter(dbCommand, "ExpedienteCodigo", DbType.String, ExpedienteCodigo);
                DB.AddInParameter(dbCommand, "MedioCodigo", DbType.String, MedioCodigo);
                DB.AddInParameter(dbCommand, "SerieCodigo", DbType.String, SerieCodigo);
                DB.AddInParameter(dbCommand, "RegPesoEnvio", DbType.String, RegPesoEnvio);
                DB.AddInParameter(dbCommand, "RegValorEnvio", DbType.String, RegValorEnvio);
                DB.AddInParameter(dbCommand, "RegistroTipo", DbType.String, RegistroTipo);
                DB.AddInParameter(dbCommand, "WFAccionCodigo", DbType.String, WFAccionCodigo);
                DB.AddInParameter(dbCommand, "WFMovimientoFechaEst", DbType.DateTime, WFMovimientoFechaEst);
                DB.AddInParameter(dbCommand, "WFMovimientoFechaFin", DbType.DateTime, WFMovimientoFechaFin);
                DB.AddInParameter(dbCommand, "WFMovimientoTipo", DbType.Int32, WFMovimientoTipo);
                DB.AddInParameter(dbCommand, "WFMovimientoNotas", DbType.String, WFMovimientoNotas);
                DB.AddInParameter(dbCommand, "WFMovimientoMultitarea", DbType.String, WFMovimientoMultitarea);
                DB.AddInParameter(dbCommand, "UserId", DbType.String, UserId);
               
                DB.ExecuteNonQuery(dbCommand);
                Result = DB.GetParameterValue(dbCommand, "@RegistroCodigo").ToString();
                string error = DB.GetParameterValue(dbCommand, "@error").ToString();
                return error;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
