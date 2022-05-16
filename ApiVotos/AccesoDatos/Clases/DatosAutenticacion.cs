using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DatosAutenticacion : IDatosAutenticacion
    {
        private readonly string CadenaConexion; 
        public DatosAutenticacion(IConfiguration config) 
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }

        public InformacionUsuario ObtenerInfoUsuarioLogin(UsuarioLogin usuarioLogin)
        {
            InformacionUsuario infoUsuario = null;
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ObtenerInfoUsuarioLogin", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Usuario", usuarioLogin.Usuario);
                command.Parameters.AddWithValue("@Password", usuarioLogin.PassWord);

                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        infoUsuario = new InformacionUsuario 
                        {
                            IdUsuario = Convert.ToInt64(reader["IdUsuario_USU"]),
                            Nombre = reader["Nombre_PER"].ToString(),
                            Apellidos = reader["Apellidos_PER"].ToString(),
                            Correo = reader["Correo_PER"].ToString(),
                            IdRol = Convert.ToInt16(reader["IdRol_USU"]),
                        };
                    }
                }
                conn.Close();
            }
            return infoUsuario;
        }
    }
}
