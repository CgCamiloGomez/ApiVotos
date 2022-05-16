using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class DatosPersona : IDatosPersona
    {
        private readonly string CadenaConexion;
        public DatosPersona(IConfiguration config)
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }

        public long CrearPersona(Persona persona)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarPersona", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Corrreo", persona.Correo);
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@IdTipoPersona", persona.IdTipoPersona);
                command.Parameters.AddWithValue("@FechaNacimiento",persona.FechaNacimiento);

                conn.Open();
                var IdPersona = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdPersona);
            }
        }
        public long CrearUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarUsuario", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPersona", usuario.IdPersona);
                command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                command.Parameters.AddWithValue("@Password", usuario.PassWord);
                command.Parameters.AddWithValue("@RegistroVoto", usuario.RegistroVoto);

                conn.Open();
                var IdUsuario = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdUsuario);
            }
        }

        public long CrearCandidato(Candidato candidato)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarCandidato", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPartido", candidato.IdPartido);
                command.Parameters.AddWithValue("@IdEvento", candidato.IdEvento);
                command.Parameters.AddWithValue("@IdPersona", candidato.IdPersona);
                command.Parameters.AddWithValue("@FotoCandidato", candidato.FotoCandidato);

                conn.Open();
                var IdCandidato = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdCandidato);
            }
        }
    }
}
