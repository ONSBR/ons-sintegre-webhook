using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

namespace ONS.Webhook.Api.Test.Security
{
    /// <summary>
    /// Handler utilizado para autenticação básica.
    /// </summary>
    /// <Author>Jose Mauro da Silva Sandy - Rerum</Author>
    /// <Date>19/07/2019 16:14:53</Date>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Constructors

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        #endregion

        #region Methods

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            var username = "";
            var password = "";
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                username = credentials[0];
                password = credentials[1];
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (!"teste".Equals(username, StringComparison.InvariantCultureIgnoreCase) || !"password".Equals(password))
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }

            var claims = new[] 
            {
                new Claim(ClaimTypes.Name, username)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        #endregion
    }
}
