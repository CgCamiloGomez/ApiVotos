using AccesoDatos.Interfaces;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Clases
{
    public class NegocioPersona : INegocioPersona
    {
        internal IDatosPersona iDatosUsuario;

        public NegocioPersona(IDatosPersona _iDatosusuario)
        {
            iDatosUsuario = _iDatosusuario;
        }

        public long CrearUsuario(Usuario usuario) 
        {
            var persona = MapearCamposPersona(usuario);
            long idUsuarioCreado = 0;
            try 
            {
                string hashPassword = CifrarPassWord(usuario.PassWord);
                usuario.PassWord = hashPassword;
                using (TransactionScope scope = new TransactionScope()) 
                {
                    var idPersona = iDatosUsuario.CrearPersona(persona);
                    usuario.IdPersona = idPersona;
                    idUsuarioCreado = iDatosUsuario.CrearUsuario(usuario);
                    scope.Complete();
                }
            }
            catch (Exception e) 
            {
                throw new Exception("Sucedio un error creando el usuario");
            }
            return idUsuarioCreado;
        }

        private Persona MapearCamposPersona(Usuario usuario) 
        {
            return new Persona 
            { 
                Nombre = usuario.Nombre,
                Identificacion = usuario.Identificacion,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Correo = usuario.Correo,
                IdTipoPersona = usuario.IdTipoPersona,
            };
        }

        private Persona MapearCamposPersona(Candidato candidato)
        {
            return new Persona
            {
                Nombre = candidato.Nombre,
                Identificacion = candidato.Identificacion,
                Apellidos = candidato.Apellidos,
                FechaNacimiento = candidato.FechaNacimiento,
                Correo = candidato.Correo,
                IdPersona = candidato.IdPersona,
            };
        }
        public string CifrarPassWord(string password) 
        {
            string hash = String.Empty;
            try
            {
                using (var md5Hash = MD5.Create())
                {
                    var sourceBytes = Encoding.UTF8.GetBytes(password);
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);
                    hash = BitConverter.ToString(hashBytes);
                }
            }
            catch (Exception e) 
            {
                throw new Exception("Ocurrio un error cifrando el password");
            }
            return hash;
        }
    }
}
