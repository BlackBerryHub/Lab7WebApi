using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;

[assembly: OwinStartup(typeof(Lab7WebApi.Startup))]

namespace Lab7WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44306/api/", //some string, normally web url,
                        ValidAudience = "https://localhost:44306/api/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("marat_lab_webapi_7"))
                    }
                });
        }
    }
}
