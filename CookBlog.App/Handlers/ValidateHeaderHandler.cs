using CookBlog.App.Services;
using System.Net.Http.Headers;

namespace CookBlog.App.Handlers;

public class ValidateHeaderHandler : DelegatingHandler
{
    private readonly ITokenService _tokenService;

    public ValidateHeaderHandler(ITokenService tokenService) 
        => _tokenService = tokenService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
    {
            var jwtToken = await _tokenService.GetToken();
            if (jwtToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken.AccessToken);

            return await base.SendAsync(request, token);
    }
}
