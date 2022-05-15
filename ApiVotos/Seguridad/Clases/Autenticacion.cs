using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Seguridad.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad.Clases
{
    public class Autenticacion : IAutenticacion
    {
        private readonly IConfiguration configuracion;
        private readonly IDatosAutenticacion datosAutenticacion;
        public Autenticacion (IConfiguration config, IDatosAutenticacion _datosAutenticacion ) 
        {
            configuracion = config;
            datosAutenticacion = _datosAutenticacion;
        }
        // COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        public InformacionUsuario AutenticarUsuarioAsync(UsuarioLogin usuario)
        {
            // AQUÍ LA LÓGICA DE AUTENTICACIÓN //
            return new InformacionUsuario()
            {
                // Id del Usuario en el Sistema de Información (BD)
                IdUsuario = 1,
                Nombre = "Nombre Usuario",
                Apellidos = "Apellidos Usuario",
                Correo = "email.usuario@dominio.com",
                IdRol = 1
            };
            // Supondremos que el Usuario NO existe en la Base de Datos.
            // Retornamos NULL.
            //return null;
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
        public string GenerarTokenJWT(InformacionUsuario usuarioInfo)
        {
            //HEADER//
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["JWT:ClaveSecreta"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var Header = new JwtHeader(signingCredentials);

            //CLAIMS//
            var Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.IdUsuario.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Correo),
                new Claim(ClaimTypes.Role, usuarioInfo.IdRol.ToString())
            };

            //PAYLOAD//
            var Payload = new JwtPayload(
                    issuer: configuracion["JWT:Issuer"],
                    audience: configuracion["JWT:Audience"],
                    claims: Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var Token = new JwtSecurityToken(Header,Payload);

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

    }
}
