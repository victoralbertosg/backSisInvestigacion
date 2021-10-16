using backSisInvestigacion.Common;
using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Request;
using backSisInvestigacion.Models.Response;
using backSisInvestigacion.tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public class UserService :IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model) {
        UserResponse userresponse = new UserResponse();
        using (var db=new bddSisInvestigacionContext())
        {
            string spassword = Encript.GetSHA256(model.Password);
            var usuario = db.Usuarios.Where(d => d.Idusuario == model.idusuario &&
                                            d.Password == spassword).FirstOrDefault();
            if (usuario == null) return null;
                userresponse.idusuario = usuario.Idusuario;
                userresponse.Token = GetToken(usuario);

        }
        return userresponse;    
        }

        private string GetToken (Usuario usuario){

            var tokenHanler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuario.Idusuario.ToString()),
                        new Claim(ClaimTypes.Role,usuario.Rol.ToString())                                               
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHanler.CreateToken(tokenDescriptor);
            return tokenHanler.WriteToken(token);

        }
}
}
