using Blazored.LocalStorage;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecommerce.WeAseembly.Extension
{
    public class AuthenticationExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ClaimsPrincipal _notInfo = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthenticationExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUser = await _localStorageService.GetItemAsync<SessionDTO>("sesionUser");

            if (sesionUser == null)
            {
                return new AuthenticationState(_notInfo);
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sesionUser.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, sesionUser.NombreCompleto),
                new Claim(ClaimTypes.Email, sesionUser.Correo),
                new Claim(ClaimTypes.Role, sesionUser.IdRol.ToString())
            }, "JwtAuth"));

            return new AuthenticationState(claimsPrincipal);
        }

        public async Task UpdateStatusAuthentication(SessionDTO? sesionUser)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesionUser != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUser.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUser.NombreCompleto),
                    new Claim(ClaimTypes.Email, sesionUser.Correo),
                    new Claim(ClaimTypes.Role, sesionUser.IdRol.ToString())
                }, "JwtAuth"));

                await _localStorageService.SetItemAsync("sesionUser", sesionUser);
            }
            else
            {
                claimsPrincipal = _notInfo;
                await _localStorageService.RemoveItemAsync("sesionUser");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
